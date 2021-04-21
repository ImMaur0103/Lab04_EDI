﻿using System;

namespace Arbol
{
    public class Nodo<T>
    {
        // Valor del nodo, el cual es el NoLinea y Nombre del fármaco
        public Tarea valor { get; set; }
        public int altura;

        //Posiciones del árbol binario
        public Nodo<T> derecha { get; set; }
        public Nodo<T> izquierda { get; set; }


        // constructor de la clase Nodo
        public Nodo()
        {
            altura = 0;
            derecha = null;
            izquierda = null;
        }
        
       // public Nodo<T> raiz; 

        ~Nodo() { }
    }
}
