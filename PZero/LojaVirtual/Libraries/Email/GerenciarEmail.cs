using LojaVirtual.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LojaVirtual.Libraries.Email
{
    public class GerenciarEmail
    {
        private SmtpClient _smtp;
        private IConfiguration _configuration;
        public GerenciarEmail(SmtpClient smtp, IConfiguration configuration)
        {
            _smtp = smtp;
            _configuration = configuration;
        }

        public void EnviarContatoPorEmail(Contato contato)
        {
            string corpoMsg = string.Format("<h2>Contato - LojaVirtual</h2>" +
                "<b>Nome  : </b> {0} <br />" +
                "<b>E-mail: </b> {1} <br />" +
                "<b>Texto : </b> {2} <br />" +
                "<br /> E-mail enviado automaticamente do site LojaVirtual.",
                contato.Nome,
                contato.Email,
                contato.Texto
                );

            /*
            * SMTP -> Servidor para enviar menssagem por email.
            */
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress(_configuration.GetValue<string>("Email:Username"));
            mensagem.To.Add(new MailAddress("ebomsil@gmail.com"));
            mensagem.Subject = "Contato - LojaVirtual - Email: " + contato.Email;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            // Enviar mensagem via SMTP
            //_smtp.Send(mensagem);
        }

        public void EnviarSenhaParaColaboradorPorEmail(Colaborador colaborador)
        {
            string corpoMsg = string.Format(
                "<h2>Colaborador - LojaVirtual</h2>" +
                "Sua senha é:" +
                "<h3>{0}</h3>", colaborador.Senha +
                "<b><br />" +
                "<b><br />" +
                "<br /> E-mail enviado automaticamente do site LojaVirtual."
                );

            /*
            * SMTP -> Servidor para enviar menssagem por email.
            */
            MailMessage mensagem = new MailMessage();
            mensagem.From = new MailAddress(_configuration.GetValue<string>("Email:Username"));
            mensagem.To.Add(new MailAddress(colaborador.Email));
            mensagem.Subject = "Colaborador - LojaVirtual - Senha do colaborador: " + colaborador.Nome;
            mensagem.Body = corpoMsg;
            mensagem.IsBodyHtml = true;

            // Enviar mensagem via SMTP
            //_smtp.Send(mensagem);
        }
    }
}
