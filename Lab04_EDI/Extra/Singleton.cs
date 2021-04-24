using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab04_EDI.Models;
using THash;
using Arbol;
using ListaDobleEnlace;

namespace Lab04_EDI.Extra 
{
    public sealed class Singleton
    {
        private readonly static Singleton instance = new Singleton();
        public InfoTarea tarea;
        public THash<InfoTarea> Thash;
        public Arbol<Tarea> THeap;
        public ListaDoble<Tarea> HeapSort;


        private Singleton()
        {
            tarea = new InfoTarea();
            Thash = new THash<InfoTarea>();
            THeap = new Arbol<Tarea>();
            HeapSort = new ListaDoble<Tarea>();
        }

        public static Singleton Instance
        {
            get
            {
                return instance; 
            }
        }

    }
}
