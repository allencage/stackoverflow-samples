using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChildTaskInParentTask
{
    class Program
    {

        //Note - basically when you call parent.Wait() it in turn waits for any child in it to finish executing and if an exception gets thrown it will wrap that into AggregateException type
        static void Main(string[] args)
        {
            Task parentTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Starting the child task");
                Task child = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Child running, going for sleep for a second");
                    Thread.Sleep(1000);
                    Console.WriteLine("Will throw an error!");
                    throw new Exception();
                }, TaskCreationOptions.AttachedToParent);
            });

            try
            {
                Console.WriteLine("Waiting for parent task");
                parentTask.Wait();
                Console.WriteLine("Parent task finished executing");
            }
            catch (AggregateException ex)
            {
                //Note - the exception that gets thrown is of type AggregateException
                Console.WriteLine("Exception is {0}", ex.InnerException.GetType());
            }
            Console.Read();
        }
    }
}
