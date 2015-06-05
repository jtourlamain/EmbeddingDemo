using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmbeddingDemo.Host
{
    class Program
    {
        static void Main(string[] args)
        {
           // AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolveOption1;
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolveOption2;
            new DemoManager().Run();
            Console.ReadLine();
        }

        static Assembly CurrentDomain_AssemblyResolveOption1(object sender, ResolveEventArgs args)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("EmbeddingDemo.Host.EmbeddedDlls.MyFramework.dll"))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData,0,assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }


        static System.Reflection.Assembly CurrentDomain_AssemblyResolveOption2(object sender, ResolveEventArgs args)
        {

            string dllName = args.Name.Contains(',') ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;

            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(typeof(Program).Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);

        }
    }
}
