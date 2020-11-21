using FarmaciaAvellaneda.Services;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmaciaAvellaneda.CustomTag
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("td", Attributes = "i-user")]
    public class UserTagHelper : TagHelper
    {
        private readonly UsersServices _users;
        public UserTagHelper(UsersServices users)
        {
            _users = users;

        }
        [HtmlAttributeName("i-user")]
        public string UserId { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string user = _users.UserName(UserId);
            output.Content.SetContent(user);
        }
    }
}
