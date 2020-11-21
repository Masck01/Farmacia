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
    [HtmlTargetElement("td", Attributes = "i-employee")]
    public class EmpleadoTagHelper : TagHelper
    {
        private readonly UsersServices _users;
        public EmpleadoTagHelper(UsersServices users)
        {
            _users = users;
        }
        [HtmlAttributeName("i-employee")]
        public string UserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string empleado = _users.EmpleadoName(UserId);
            output.Content.SetContent(empleado);

        }
    }
}
