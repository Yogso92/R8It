using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestAdo
{
    public class testSingleton
    {
        public testSingleton()
        {
            CategoryRepository service = DALService.GetService<CategoryRepository>();
            Console.WriteLine("building testsingleton");
        }
    }
}
