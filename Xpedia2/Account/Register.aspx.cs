using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Xpedia2.Models;
using ArangoDB.Client;
using System.Collections.Generic;

namespace Xpedia2.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {

            string usuario = Email.Text;
            string nombre = Nombre.Text;
            string contrasenia = Password.Text;

            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            using (ArangoDatabase db = new ArangoDatabase(url: "http://52.32.98.159:8529", database: "Expedia"))
            {

                //var usuariodb = new Usuarios { nombre = nombre, usuario = usuario, contrasenia = contrasenia };                
                //db.Insert<Usuarios>(usuariodb);
                



                //Session["usuario"] = usuariodb.usuario;
                //IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                //}
                //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

            }
            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            //var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            //IdentityResult result = manager.Create(user, Password.Text);
            //if (result.Succeeded)
            //{
            //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //    //string code = manager.GenerateEmailConfirmationToken(user.Id);
            //    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
            //    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

            //    signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
            //   
            //else 
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}
        }
    }
}