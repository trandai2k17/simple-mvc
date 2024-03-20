using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using simple_mvc.Application.Common.Interfaces;
using simple_mvc.Domain.Contants;
using simple_mvc.Domain.Entities;
using simple_mvc.Web.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace simple_mvc.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IUnitOfWork unitOfWork, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Login(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            LoginVM loginVM = new LoginVM()
            {
                ReturnUrl = returnUrl
            };
            return View(loginVM);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(loginVM.Email, loginVM.Password, loginVM.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(loginVM.Email);

                    //if (user != null && await _userManager.IsInRoleAsync(user, "Admin"))
                    //{
                    //    return RedirectToAction("Index", "Dashboard");
                    //}
                    

                    if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return LocalRedirect(loginVM.ReturnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                }
            }
            
            return View(loginVM);
        }

        public IActionResult Register()
        {

            if(!_roleManager.RoleExistsAsync(RoleContanst.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(RoleContanst.Role_Admin)).Wait();
                _roleManager.CreateAsync(new IdentityRole(RoleContanst.Role_Public)).Wait();
                _roleManager.CreateAsync(new IdentityRole(RoleContanst.Role_Staff)).Wait();
                _roleManager.CreateAsync(new IdentityRole(RoleContanst.Role_Manager)).Wait();
                _roleManager.CreateAsync(new IdentityRole(RoleContanst.Role_HeadOfManager)).Wait();
                _roleManager.CreateAsync(new IdentityRole(RoleContanst.Role_Suppervisor)).Wait();
                _roleManager.CreateAsync(new IdentityRole(RoleContanst.Role_Director)).Wait();
            }

            RegisterVM registerVM = new RegisterVM()
            {
                RoleList = _roleManager.Roles.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id
                })
            };
            return View(registerVM);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Name = registerVM.Name,
                Email = registerVM.Email,
                PhoneNumber = registerVM.PhoneNumber,
                NormalizedEmail = registerVM.Email.ToUpper(),
                EmailConfirmed = true,
                UserName = registerVM.Email,
                CreatedDate = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if(result.Succeeded)
            {
                if(!string.IsNullOrEmpty(registerVM.Role)) {
                    await _userManager.AddToRoleAsync(user, registerVM.Role);
                }else
                {
                    await _userManager.AddToRoleAsync(user, RoleContanst.Role_Staff);
                }

                await _signInManager.SignInAsync(user, isPersistent: false);

                if(string.IsNullOrEmpty(registerVM.ReturnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return LocalRedirect(registerVM.ReturnUrl);
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            registerVM.RoleList = _roleManager.Roles.Select(x => x.Name)
                .Select(m => new SelectListItem
            {
                Text = m,
                Value = m
            });

            return View(registerVM);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
