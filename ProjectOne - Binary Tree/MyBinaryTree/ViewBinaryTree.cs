using System;

namespace MyBinaryTree
{

    // Creates a binary tree view

    class ViewBinaryTree
    {
        public void BinaryTreeView()
        {
            Console.WriteLine(new string(' ', 23) + "BINARY TREE");
            Console.WriteLine();
            Console.WriteLine(" Sample login: root: 10 and nodes: 7, 15, 8, 1, 3, 5, 18 ");
            Console.WriteLine(new string('-', 56));
            Console.WriteLine(new string(' ',24) + " Root: 10 " + new string(' ',22));
            Console.WriteLine(new string(' ', 23) + " / " + new string(' ', 6) + " \\ " + new string(' ', 21));
            Console.WriteLine(new string(' ', 17) + " Node: 7 " + new string(' ', 6) + " Node: 15 " + new string(' ', 14));
            Console.WriteLine(new string(' ', 16) 
                              + " / " 
                              + new string(' ', 2) 
                              + " \\ " 
                              + new string(' ', 10)                              
                              + " \\ " 
                              + new string(' ', 18));
            Console.WriteLine(new string(' ', 10) 
                              + " Node: 1 " 
                              + new string(' ', 2) 
                              + " Node: 8 " 
                              + new string(' ', 4) 
                              + " Node: 18 " 
                              + new string(' ', 11));
            Console.WriteLine(new string(' ', 15) + " \\ " + new string(' ', 37));
            Console.WriteLine(new string(' ', 14) + " Node: 5 " + new string(' ', 32));
            Console.WriteLine(new string('-', 56));
            Console.WriteLine();
        }        
    }
}
