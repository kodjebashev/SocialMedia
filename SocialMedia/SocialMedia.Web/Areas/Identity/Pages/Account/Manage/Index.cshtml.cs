namespace SocialMedia.Web.Areas.Identity.Pages.Account.Manage
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using SocialMedia.Data;
    using SocialMedia.Data.Models;

    public partial class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly SocialMediaDbContext _context;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            SocialMediaDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._context = context;
        }

        //TODO: User/Profile picture
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Телефон")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Име")]
            public string FirstName { get; set; }

            [Display(Name = "Фамилия")]
            public string LastName { get; set; }

            //TODO: Date picker
            [Display(Name = "Дата на раждане")]
            [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
            public DateTime? DOB { get; set; }

            [Display(Name = "Град")]
            public string City { get; set; }

            [Display(Name = "Държава")]
            public string Country { get; set; }

            [Display(Name = "Пол")]
            public Gender Gender { get; set; }

            [Display(Name = "Био")]
            public string Bio { get; set; }
            [Display(Name = "Клас")]
            public string Grade { get; set; }
            [Display(Name = "Специалност")]
            public string Speciality { get; set; }
            [Display(Name = "Класен пъководител")]
            public string Tutor { get; set; }
            [Display(Name = "Успех")]
            public string MidGrades { get; set; }
            [Display(Name = "Мейл")]
            public string Email { get; set; }
            [Display(Name = "Адрес")]
            public string Address { get; set; }

        }

        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);

            Username = userName;

            Input = new InputModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Gender = user.Gender,
                DOB = user.DOB,
                Bio = user.Bio,
                City = user.City,
                Country = user.Country,
                Address = user.Address,
                Email = user.Email,
                Grade = user.Grade,
                MidGrades = user.MidGrades,
                PhoneNumber = user.PhoneNumber,
                Speciality = user.Speciality,
                Tutor = user.Tutor
                
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            //Update details
            if (Input.FirstName != user.FirstName)
            {
                try
                {
                    var updateUser = await this._context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    updateUser.FirstName = this.Input.FirstName;
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    StatusMessage = "Your first name has not been updated";
                    return RedirectToPage();
                }

            }






            //Update details
            if (Input.Grade != user.Grade)
            {
                try
                {
                    var updateUser = await this._context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    updateUser.Grade = this.Input.Grade;
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    StatusMessage = "Your grade has not been updated";
                    return RedirectToPage();
                }

            }  //Update details
            if (Input.Speciality != user.Speciality)
            {
                try
                {
                    var updateUser = await this._context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    updateUser.Speciality = this.Input.Speciality;
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    StatusMessage = "Your spec has not been updated";
                    return RedirectToPage();
                }

            }
            //Update details
            if (Input.Tutor != user.Tutor)
            {
                try
                {
                    var updateUser = await this._context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    updateUser.Tutor = this.Input.Tutor;
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    StatusMessage = "Your tutor name has not been updated";
                    return RedirectToPage();
                }

            }
            if (Input.MidGrades != user.MidGrades)
            {
                try
                {
                    var updateUser = await this._context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    updateUser.MidGrades = this.Input.MidGrades;
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    StatusMessage = "Your midgrade has not been updated";
                    return RedirectToPage();
                }

            }

            if (Input.PhoneNumber != user.PhoneNumber)
            {
                try
                {
                    var updateUser = await this._context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    updateUser.PhoneNumber = this.Input.PhoneNumber;
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    StatusMessage = "Your phn has not been updated";
                    return RedirectToPage();
                }

            }
            if (Input.Email != user.Email)
            {
                try
                {
                    var updateUser = await this._context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    updateUser.Email = this.Input.Email;
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    StatusMessage = "Your email has not been updated";
                    return RedirectToPage();
                }

            }
            if (Input.Address != user.Address)
            {
                try
                {
                    var updateUser = await this._context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    updateUser.Address = this.Input.Address;
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    StatusMessage = "Your sdrs has not been updated";
                    return RedirectToPage();
                }

            }

            if (Input.LastName != user.LastName)
            {
                try
                {
                    var updateUser = await this._context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    updateUser.LastName = this.Input.LastName;
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    StatusMessage = "Your last name has not been updated";
                    return RedirectToPage();
                }

            }
            if (Input.DOB != user.DOB)
            {
                try
                {
                    var updateUser = await this._context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    updateUser.DOB = Input.DOB;
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    StatusMessage = "Your date of birth has not been updated";
                    return RedirectToPage();
                }

            }
            if (Input.Gender != user.Gender)
            {
                try
                {
                    var updateUser = await this._context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    updateUser.Gender = Input.Gender;
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    StatusMessage = "Your gender has not been updated";
                    return RedirectToPage();
                }

            }
            if (Input.Bio != user.Bio)
            {
                try
                {
                    var updateUser = await this._context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    updateUser.Bio = Input.Bio;
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    StatusMessage = "Your bio has not been updated";
                    return RedirectToPage();
                }

            }
            if (Input.Country != user.Country)
            {
                try
                {
                    var updateUser = await this._context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    updateUser.Country = Input.Country;
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    StatusMessage = "Your country has not been updated";
                    return RedirectToPage();
                }

            }
            if (Input.City != user.City)
            {
                try
                {
                    var updateUser = await this._context.Users.FirstOrDefaultAsync(i => i.Id == user.Id);
                    updateUser.City = Input.City;
                    await this._context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    StatusMessage = "Your city has not been updated";
                    return RedirectToPage();
                }

            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
