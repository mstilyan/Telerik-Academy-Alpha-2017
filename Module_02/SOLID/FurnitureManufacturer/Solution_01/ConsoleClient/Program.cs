using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Engine.Commands;
using FurnitureManufacturer.Engine.Factories;
using FurnitureManufacturer.Engine.Repositories;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Engine;
using FurnitureManufacturer.Interfaces.Factories;
using FurnitureManufacturer.Interfaces.Repository;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerConfig = new AutofacConfic();
            var container = containerConfig.Build();

            var engine = container.Resolve<IFurnitureManufacturerEngine>();
            engine.Start();
        }
    }
}
