using System;
using System.Collections.Generic;
using System.Text;

namespace CustomListLib
{
    public class Node<T>
    {
        /// <summary>
        /// This property show the valu of node
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// This property save the information about next node in stack
        /// </summary>
        public Node<T> Next { get; set; }
        /// <summary>
        /// This constructor set value for node
        /// </summary>
        /// <param name="Value">any value of some type "T" for node</param>
        public Node(T data)
        {
            Data = data;
        }
    }
}
