using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace text
{
    class MFileWatcher
    {
        public static void Run(string[] ss)
        {
            foreach (string s in ss)
            {
                MyFileSystemWather.Instance.check();
                MyFileSystemWather.Instance.setPath(s);
                MyFileSystemWather.Instance.setFilter("*.*");
                   MyFileSystemWather.Instance.OnChanged += new FileSystemEventHandler(OnChanged);
            MyFileSystemWather.Instance.OnCreated += new FileSystemEventHandler(OnCreated);
            MyFileSystemWather.Instance.OnRenamed += new RenamedEventHandler(OnRenamed);
            MyFileSystemWather.Instance.OnDeleted += new FileSystemEventHandler(OnDeleted);
            MyFileSystemWather.Instance.check();
           // MyFileSystemWather.Instance.Start();
          //  MyFileSystemWather.Instance.Stop();
            MyFileSystemWather.Instance.Start();
            //由于是控制台程序，加个输入避免主线程执行完毕，看不到监控效果
            Console.ReadKey();
            }
        }
 
        private static void OnCreated(object source, FileSystemEventArgs e)
        {

            Console.WriteLine("文件新建事件 {0}  {1}  {2} {3} ", e.ChangeType, e.FullPath, e.Name, DateTime.Now.ToString(("yyyyMMddHHmmss")));
             
        }
 
        private static void OnChanged(object source, FileSystemEventArgs e)
        {

            Console.WriteLine("文件改变事件{0}  {1}  {2} {3}", e.ChangeType, e.FullPath, e.Name, DateTime.Now.ToString(("yyyyMMddHHmmss")));
        }
 
        private static void OnDeleted(object source, FileSystemEventArgs e)
        {

            Console.WriteLine("文件删除事件{0}  {1}   {2} {3}", e.ChangeType, e.FullPath, e.Name, DateTime.Now.ToString(("yyyyMMddHHmmss")));
        }
 
        private static void OnRenamed(object source, RenamedEventArgs e)
        {

            Console.WriteLine("文件重命名事件{0}  {1}  {2} {3}", e.ChangeType, e.FullPath, e.Name, DateTime.Now.ToString(("yyyyMMddHHmmss")));
        }
            
        
    }
}
