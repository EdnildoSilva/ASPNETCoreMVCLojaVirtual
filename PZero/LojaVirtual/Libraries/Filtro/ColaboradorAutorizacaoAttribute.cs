﻿using LojaVirtual.Libraries.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Filtro
{
    public class ColaboradorAutorizacaoAttribute : Attribute, IAuthorizationFilter
    {
        LoginColaborador _loginColaborador;
        private string _tipoColaboradorAutorizado;

        public ColaboradorAutorizacaoAttribute(string tipoColaboradorAutorizado = "C")
        {
            _tipoColaboradorAutorizado = tipoColaboradorAutorizado;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _loginColaborador = (LoginColaborador)context.HttpContext.RequestServices.GetService(typeof(LoginColaborador));
            Models.Colaborador colaborador = _loginColaborador.GetColaborador();

            if (colaborador == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", null);
            }
            else 
            {
                if(_tipoColaboradorAutorizado == "G")
                {
                    if (colaborador.Tipo != "G")
                    {
                        context.Result = new ForbidResult();
                    }
                }
                else if (colaborador.Tipo != "C" && colaborador.Tipo != "G") 
                {
                    context.Result = new ForbidResult();
                }
            }
        }
    }

}
