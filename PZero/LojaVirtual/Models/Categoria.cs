﻿using LojaVirtual.Libraries.Lang;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LojaVirtual.Models
{
    public class Categoria
    {
        //PK
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E002")]
        public string Nome { get; set; }

        /*
         * Nome: Telefone sem fio
         * Slug: telefone-sem-fio
         * www.lojavirtual.com.br/categoria/informatica (Url amigavel e com Slug)
         */
        [Required(ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(4, ErrorMessageResourceType = typeof(Mensagem), ErrorMessageResourceName = "MSG_E002")]
        public string Slug { get; set; }

        /*
         * Auto-relacionamento
         * 1-Informatica        - P:null
         * - 2-Mouse            - P:1
         * -- 3-Mouse sem fio   - P:2
         * -- 4-Mouse Gamer     - P:2
         */
        [Display(Name = "Categoria Pai")]
        public int? CategoriaPaiId { get; set; }

        /*
         * ORM - Entity\frameworkCore
         */
        [ForeignKey("CategoriaPaiId")]
        public virtual Categoria CategoriaPai{ get; set;}
    }
}
