﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using NythAPI.Controllers;
using NythWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace NythTest
{
    public class CategoriasControllerTest
    {

        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Categoria _categoria;


        public CategoriasControllerTest()
        {

           _mockSet = new Mock<DbSet<Categoria>>();
           _mockContext = new Mock<Context>();
           _categoria = new Categoria { Id = 1, Descricao = "Teste de Categoria" };

            _mockContext.Setup(x => x.Categorias).Returns(_mockSet.Object);

           _mockContext.Setup(x => x.Categorias.FindAsync()).ReturnsAsync(_categoria);
            

        }

        [Fact]

        public async Task Get_Categoria()
         {
            var service = new CategoriasController(_mockContext.Object);

            await service.GetCategoria(1);

          _mockSet.Verify(x => x.FindAsync(1), Times.Once());

          

          }

        

    }
}

