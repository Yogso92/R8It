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
            CategoryService service = DALService.GetService<CategoryService>();
            Console.WriteLine("building testsingleton");
        }
    }
}
