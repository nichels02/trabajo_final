using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listas : MonoBehaviour
{
    public class pila<T>
    {
        public class node
        {
            T valor;
            int cantidadDeBalas;
            int cantidadDeBalasTotales;
            int cantidadDeBalasCargador;
            float tiempoMax;
            node next;
            node previus;

            public T Valor
            {
                get { return valor; }
                set { valor = value; }
            }
            public node Next
            {
                get { return next; }
                set { next = value; }
            }
            public node Previous
            {
                get { return previus; }
                set { previus = value; }
            }
            public int CantidadDeBalas
            {
                get { return cantidadDeBalas; }
                set { cantidadDeBalas = value; }
            }
            public int CantidadDeBalasTotales
            {
                get { return cantidadDeBalasTotales; }
                set { cantidadDeBalasTotales = value; }
            }
            public int CantidadDeBalasCargador
            {
                get { return cantidadDeBalasCargador; }
                set { cantidadDeBalasCargador = value; }
            }
            public float TiempoMax
            {
                get { return tiempoMax; }
                set { tiempoMax = value; }
            }
            public node(T v)
            {
                valor = v;
            }
            public node(T v, int cantidad, int cargador, float tiempo)
            {
                valor = v;
                cantidadDeBalas = cantidad;
                cantidadDeBalasCargador = cargador;
                tiempoMax = tiempo;
            }
            public node(T v, int cantidad, int cargador, int totales , float tiempo)
            {
                valor = v;
                cantidadDeBalas = cantidad;
                cantidadDeBalasCargador = cargador;
                cantidadDeBalasTotales = totales;
                tiempoMax = tiempo;
            }
        }

        node head;
        node tail;
        int cantidad;

        public node Head
        {
            get { return head; }
            set { head = value; }
        }



        public void Add(T dato, int cantidad, int cargador, float tiempo)
        {
            node newnode = new node(dato, cantidad, cargador, tiempo);
            if(head == null)
            {
                head = newnode;
                tail = newnode;
                cantidad = cantidad + 1;
            }
            else
            {
                node tmp = head;
                tmp.Previous = newnode;
                newnode.Next = tmp;
                head = newnode;
                cantidad = cantidad + 1;
            }
        }
        public void Add2(T dato, int cantidad, int cargador, int total, float tiempo)
        {
            node newnode = new node(dato, cantidad, cargador, total, tiempo);
            if (head == null)
            {
                head = newnode;
                tail = newnode;
                cantidad = cantidad + 1;
            }
            else
            {
                node tmp = head;
                tmp.Previous = newnode;
                newnode.Next = tmp;
                head = newnode;
                cantidad = cantidad + 1;
            }
        }


        public void remove()
        {
            node tmp = head;
            node newhead = head.Next;

            newhead.Previous = null;
            tmp.Next = null;
            head = newhead;
            cantidad = cantidad - 1;
        }

    }


    public class elgrafo<T>
    {
        public class node
        {
            T valor;
            node next;
            node previus;
            public int orden;
            Vector3 elvector;
            public listaDeDobleSentido<conexiones> lista = new listaDeDobleSentido<conexiones>();

            public T Valor
            {
                get { return valor; }
                set { valor = value; }
            }
            public node Next
            {
                get { return next; }
                set { next = value; }
            }
            public node Previous
            {
                get { return previus; }
                set { previus = value; }
            }
            public Vector3 Elvector
            {
                get { return elvector; }
                set { elvector = value; }
            }



            public node(T valor, int elOrden)
            {
                Valor = valor;
                orden = elOrden;
            }



            public conexiones PositionConexion(int position)
            {
                conexiones conexion = lista.Position(position).Valor;
                return conexion;
            }

            public int GetConexionDesgastePosition(int positionConexion)
            {
                conexiones tmp = PositionConexion(positionConexion);
                int x;
                x = tmp.Desgaste;
                return x;
            }

            public T GetConexionNodePosition(int positionConexion)
            {
                conexiones tmp = PositionConexion(positionConexion);
                T x;
                x = tmp.Valor.valor;
                return x;
            }

        }





        public class conexiones
        {
            node valor;
            int desgaste;

            public node Valor
            {
                get { return valor; }
                set { valor = value; }
            }
            public int Desgaste
            {
                get { return desgaste; }
                set { desgaste = value; }
            }


            public conexiones(node valor, int desgaste)
            {
                Valor = valor;
                Desgaste = desgaste;
            }
        }


        #region componentesDeLista
        node head;
        node tail;
        node especial;
        int cantidad;

        public node Head
        {
            get { return head; }
            set { head = value; }
        }
        public node Tail
        {
            get { return tail; }
            set { tail = value; }
        }
        public node Especial
        {
            get { return especial; }
            set { especial = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        #endregion


        #region lista
        public void AddNodeStar(T valou, int elOrden)
        {
            if (head == null)
            {
                node newnode = new node(valou, elOrden);
                head = newnode;
                tail = newnode;
                cantidad = cantidad + 1;
            }
            else
            {
                node newnode = new node(valou, elOrden);
                node tmp = head;
                head = newnode;
                newnode.Next = tmp;
                tmp.Previous = newnode;
                head.Previous = tail;
                tail.Next = head;
                cantidad = cantidad + 1;
            }
        }

        public void AddNodeEnd(T valou, int elOrden)
        {
            if (head == null)
            {
                AddNodeStar(valou, elOrden);
            }
            else
            {
                node newnode = new node(valou, elOrden);
                node tmp = tail;
                tail = newnode;
                tmp.Next = newnode;
                newnode.Previous = tmp;
                head.Previous = tail;
                tail.Next = head;
                cantidad = cantidad + 1;
            }
        }
        public node Position(int position)
        {
            int recorrido = 0;
            node tmp = head;
            while (recorrido < position)
            {
                tmp = tmp.Next;
                recorrido = recorrido + 1;
            }
            return tmp;
        }
        #endregion

        public T GetNodePositin(int position)
        {
            node tmp = Position(position);
            T x;
            x = tmp.Valor;
            return x;
        }

        public T GetNodeEspecial()
        {
            node tmp = Especial;
            T x;
            x = tmp.Valor;
            return x;
        }





        public void addConexion(int nodo, int conexion, int desgaste)
        {
            node tmp = Position(nodo);
            node tmpConexion = Position(conexion);
            conexiones tmoC = new conexiones(tmpConexion, desgaste);
            tmp.lista.AddNodeEnd(tmoC);
            if (tmp != tmpConexion)
            {
                /*
                if (tmp.lista.Head.Valor.Valor == tmpConexion)
                {
                    Debug.Log("1");
                }
                else
                {
                    Debug.Log("2");
                }
                */
            }

        }

        #region DarValorAEspecial
        public void modificarEspecial(int posicionEspecial)
        {
            node node = Position(posicionEspecial);
            Especial = node;
        }

        public void modificarEspecialNext(int posicionEspecial)
        {
            especial = especial.lista.Head.Valor.Valor;
        }

        #endregion

    }


    public class listaDeDobleSentido<T>
    {
        public class node
        {
            T valor;
            node next;
            node previus;
            public T Valor
            {
                get { return valor; }
                set { valor = value; }
            }
            public node Next
            {
                get { return next; }
                set { next = value; }
            }
            public node Previous
            {
                get { return previus; }
                set { previus = value; }
            }


            public node(T valor)
            {
                Valor = valor;
            }
        }


        node head;
        node tail;
        int cantidad;

        public node Head
        {
            get { return head; }
            set { head = value; }
        }
        public node Tail
        {
            get { return tail; }
            set { tail = value; }
        }
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        public void AddNodeStar(T valou)
        {
            if (head == null)
            {
                node newnode = new node(valou);
                head = newnode;
                tail = newnode;
                cantidad = cantidad + 1;
            }
            else
            {
                node newnode = new node(valou);
                node tmp = head;
                head = newnode;
                newnode.Next = tmp;
                tmp.Previous = newnode;
                head.Previous = tail;
                tail.Next = head;
                cantidad = cantidad + 1;
            }
        }

        public void AddNodeEnd(T valou)
        {
            if (head == null)
            {
                AddNodeStar(valou);
            }
            else
            {
                node newnode = new node(valou);
                node tmp = tail;
                tail = newnode;
                tmp.Next = newnode;
                newnode.Previous = tmp;
                head.Previous = tail;
                tail.Next = head;
                cantidad = cantidad + 1;
            }
        }
        public node Position(int position)
        {
            int recorrido = 0;
            node tmp = head;
            while (recorrido < position - 1)
            {
                tmp = tmp.Next;
                recorrido = recorrido + 1;
            }
            return tmp;
        }


        public T GetNodePositin(int position)
        {
            node tmp = Position(position);
            T x;
            x = tmp.Valor;
            return x;
        }


    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
