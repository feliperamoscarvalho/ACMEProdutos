namespace ACMEProdutos.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ACMEProdutos.Models.ACMEProdutosContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ACMEProdutos.Models.ACMEProdutosContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Clientes.AddOrUpdate(p => p.Nome,
                new Cliente
                {
                    Nome = "Coiote",
                    Email = "coiote@gmail.com",
                    Telefone = "01133445566"
                },
                new Cliente
                {
                    Nome = "Papa-Léguas",
                    Email = "papa_leguas@gmail.com",
                    Telefone = "01199990011"
                });

        }
    }
}
