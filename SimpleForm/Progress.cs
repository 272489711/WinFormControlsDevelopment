using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SimpleForm
{
    class Progress
    {
        
        public static void Main()
        {
            Console.WriteLine("按任意键打开窗口调试自定义控件！");
            Console.ReadKey();
            new MyForm().ShowDialog();
            //Application.Run(new MyForm());
          
            Console.ReadKey();

        }
       
    }
}
