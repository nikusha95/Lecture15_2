// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;

var obj = new object();

Thread t1 = new Thread(Method1)
{
    Name = "Thread 1 is working"
};

Thread t2 = new Thread(Method1)
{
    Name = "Thread 2 is working"
};


// t1.Start();
// Method1();
//t2.Start();

//new Thread(() => { Console.WriteLine("Hi"); /*return 0;*/ }).Start();

//wait 5 second
//Thread.Sleep(1000);
//await Task.Delay(5000);
//new Thread(message => { Console.WriteLine(message);}).Start("hello");

// for (int i = 0; i < 10; i++)
// {
//     new Thread(() => { Console.Write(i);}).Start();
// }

//void <=====> Task

Task<int> task = Task.Run(() =>
{
    Console.WriteLine("Hello");
    Thread.Sleep(1000);
    //await Task.Delay(1000);
    Console.WriteLine("Hi");
    return 10;
}, CancellationToken.None);

//task.Wait();

TaskAwaiter<int> awaiter = task.GetAwaiter();

awaiter.OnCompleted(() => { Console.WriteLine("Task has been completed"); });
int x = awaiter.GetResult();

Console.WriteLine($"Task result {x}");
Console.WriteLine($"status-->{task.Status}");
Console.WriteLine($"isCompleted-->{task.IsCompleted}");

Console.WriteLine("main Program");

//Task.Factory.StartNew(() => { Console.WriteLine("Hi"); });


await Task.Run(() =>
{
    Console.WriteLine("Hello with await");
    //Thread.Sleep(1000);
    //await Task.Delay(1000);
    Console.WriteLine("Hi with await");
    // return 10;
});

Task tk1 = Task.Run(() => { Console.WriteLine("Task 1 is working"); });
Task tk2 = Task.Run(() => { Console.WriteLine("Task 2 is working"); });
Task tk3 = Task.Run(() => { Console.WriteLine("Task 3 is working"); });


await tk2;
await tk1;
await tk3;


int index = Task.WaitAny(tk1, tk2, tk3);

Console.WriteLine(index);

void Method1()
{
    var lockObj = new object();

    for (int i = 0; i < 100; i++)
    {
        lock (lockObj)
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            Console.WriteLine($"M1 {i}");
        }
    }
}

void Method2()
{
    var lock2 = new object();
    for (int i = 0; i < 100; i++)
    {
        lock (lock2)
        {
            Console.WriteLine(Thread.CurrentThread.Name);
            Console.WriteLine($"M2 {i}");
        }
    }
}