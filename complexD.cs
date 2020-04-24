using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumereComplexe
{
    class ComplexD : Complex
    {
        Complex temp = new Complex(5, 2);
        double r;
        double t;

        public ComplexD() : this(0, 0)
        {

        }
        public ComplexD(double p_reala) : this(p_reala, 0)
        {

        }
        public ComplexD(double p_reala, double p_imaginara)
        {
            parte_imaginara = p_imaginara;
            parte_reala = p_reala;
        }


        public void Dist(List<Complex> multimeNRcplx)
        {

            Complex[] v = multimeNRcplx.ToArray();
            double min = Math.Sqrt(Math.Pow(temp.ParteReala() - v[0].ParteReala(), 2) + Math.Pow(temp.ParteImaginara() - v[0].ParteImaginara(), 2));
            double distanta;

            for (int i = 1; i < v.Length; i++)
            {
                distanta = Math.Sqrt(Math.Pow(temp.ParteReala() - v[i].ParteReala(), 2) + Math.Pow(temp.ParteImaginara() - v[i].ParteImaginara(), 2));
                if (distanta < min)
                    min = distanta;
            }

            Console.WriteLine("Distanta minima este:{0}", min);
        }

        public override string RidicareaCuFormaTrig(Complex nr, int putere)
        {
            Complex c = new Complex();

            for (int i = 1; i < putere; i++)
            {
                c += nr * nr;
            }

            t = Math.Atan(c.ParteImaginara() / c.ParteReala());
            r = Math.Sqrt((c.ParteReala() * c.ParteReala()) + (c.ParteImaginara() * c.ParteImaginara()));

            return "Ridicarea la putere sub forma trigonometrica: x= " + r + "*(cos(" + t + ") + i*sin(" + t + "))";
        }


    }
}
