using FarmaciaAvellaneda.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaAvellaneda.CustomTag
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("td", Attributes = "i-role")]
    public class RoleTagHelper : TagHelper
    {
        private readonly UsersServices _users;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleTagHelper(UserManager<IdentityUser> manager, RoleManager<IdentityRole> role, UsersServices users)
        {
            _users = users;
            _userManager = manager;
            _roleManager = role;
        }

        [HtmlAttributeName("i-role")]
        public string UserId { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {

            List<string> names = await _users.GetUserInRolesAsync(UserId);
            //IdentityRole role = await _roleManager.FindByIdAsync(UserId);

            //if (role != null)
            //{
            //    foreach (var user in _userManager.Users)
            //    {
            //        if (user != null && await _userManager.IsInRoleAsync(user, role.Name))
            //        {
            //            names.Add(user.UserName);
            //        }
            //    }
            //}
            output.Content.SetContent(names.Count == 0 ? "Sin usuarios" : string.Join(", ", names));
        }
    }
}
