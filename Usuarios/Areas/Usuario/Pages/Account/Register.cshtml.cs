using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Usuarios.Areas.Usuario.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private UserManager<IdentityUser> _userManager;
        public RegisterModel(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public void OnGet()
        {
            
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage ="El campo E-mail es obligatorio")]
            [EmailAddress]
            [Display(Name ="Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "El campo contraseña es obligatorio")]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            [StringLength(15, ErrorMessage ="Él número de caracteres de {0} debe ser de al menos {2}.",MinimumLength = 6)]
            public string Password { get; set; }

            [Required(ErrorMessage = "El campo confirmar contraseña es obligatorio")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirmar Password")]
            [Compare("Password", ErrorMessage ="The password and confirmation password do not mach.")]
            public string ConfirmPassword { get; set; }

            public string ErrorMessage { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userList = _userManager.Users.Where(u => u.Email.Equals(Input.Email)).ToList();
                if (userList.Count.Equals(0))
                {
                    var user = new IdentityUser
                    {
                        UserName = Input.Email,
                        Email = Input.Email
                    };
                    var result = await _userManager.CreateAsync(user, Input.Password);
                    if (result.Succeeded)
                    {
                        return Page();
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            Input = new InputModel
                            {
                                ErrorMessage = item.Description
                            };
                        }
                        return Page();
                    }
                }
                else
                {
                    Input = new InputModel
                    {
                        ErrorMessage = $"El {Input.Email} ya está registrado",
                    };
                }
            }
            //else if (Input.Email == null)
            //{
            //    ModelState.AddModelError("Input.Email","El campo no es valido");
            //}
            //else if (Input.Password == null)
            //{
            //    ModelState.AddModelError("Input.Password", "El campo no es valido");
            //}
            //else if (Input.ConfirmPassword == null)
            //{
            //    ModelState.AddModelError("Input.ConfirmPassword", "El campo no es valido");
            //}
            var data = Input;
            return Page();
        }
    }
}
