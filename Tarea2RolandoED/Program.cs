using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//Programacion2Rolando
namespace Tarea2RolandoED
{
    class Program
    {
        static String _header = "\n==============================\n\tCajero Banco Estado";
        static String _menu = "1. Depósito de dinero\n2. Retiro de dinero\n3. Recibo de monedas\n4. Consulta tipo de cambio\n8. Update Exchange Rate\n5. Salir";
        static int option = 0;
        static float capital = 0;
        static string salidaCompleta = "";
        static double USD = 534.75;
        //static sealed double USD2 = 534.75;
                
        static int Main(string[] args)
        {
            //Webservice();
            while (true)
            {
                Console.WriteLine(_header);
                Console.WriteLine("Capital : ¢" + capital);
                ////string s = Console.ReadLine();
                ////Console.WriteLine("lenght" + s.Length);
                ////Console.WriteLine("lenght" + s.Substring(1, 4));
                ////StringBuilder sb = new StringBuilder(s.Substring(1, s.Length));
                ////sb[1] = 'a';
                ////sb[2] = 'b';
                ////sb[3] = 'c';
                ////string enew = sb.ToString();

                //////Console.WriteLine("new is : " + int.Parse(enew));
                ////Console.WriteLine("new is : " + enew);
                // aca
                //Console.WriteLine("lenght" + s.char;
                Console.WriteLine(_menu);
                try{
                    option = int.Parse(Console.ReadLine());
                if (option == 5)
	            {
                    return 1;
	            }
                else if (option == 1)
                {
                    depositar_dinero();
                    option = 0;
                }
                else if (option == 2)
                {
                    Console.WriteLine("Ingrese la cantidad de dinero a retirar: ");
                    string send = Console.ReadLine();
                    int amount = int.Parse(send);
                    retirar_dinero(amount);
                    option = 0;
                }
                else if (option == 3)
                {
                    recibir_monedas();
                    option = 0;
                }
                else if (option == 4)
                {
                    indicar_tipodecambio();                    
                    option = 0;
                }
                else if (option == 8)
                {
                    Webservice();
                }
                //else if (option == 7)
                //{
                //    probar();
                //    option = 0;
                //}
                else if (option == 6 || option == 0){
                    Console.Clear();
                }
                else { 
                    Console.WriteLine("\nERROR Numero de opcion incorrecto\n");
                }
                }
                catch (System.Exception e)
                {                    
                    Console.WriteLine("\nERROR " + e.Message+"\n");
                }
            }
            //return 1;
        }
        #region METODOS de TAREA
        //-1
        static void depositar_dinero() {
            try
            {
                Console.WriteLine("\nIngrese la cantidad a depositar :");
                capital += int.Parse(Console.ReadLine());
            }
            catch (System.Exception e)
            {
                Console.WriteLine("\nERROR " + e.Message + "\n");
            }
        }
        //-2
        static void retirar_dinero(int amount)
        {
            int total = amount;
            List<int> billetes = new List<int>(new int[] { 0, 0, 0, 0 });
            bool huboproblemas = false;
            int cont = 0;
            if (capital > 0 && capital >= amount)
            {
                while (total > 0)
                {
                    //Console.WriteLine("entro al while");
                    if (total > 20000)
                    {
                        billetes[0] = billetes[0] + 1;
                        total -= 20000;
                    }
                    else if (total % 20000 == 0)
                    {
                        billetes[0] = billetes[0] + (total / 20000);
                        total -= 20000 * (total / 20000);
                    }
                    else if (total % 10000 == 0)
                    {
                        billetes[1] = billetes[1] + (total / 10000);
                        total -= 10000 * (total / 10000);
                    }
                    else if (total > 10000)
                    {
                        billetes[1] = billetes[1] + 1;
                        total -= 10000;
                    }
                    else if (total % 5000 == 0)
                    {
                        billetes[2] = billetes[2] + (total / 5000);
                        total -= 5000 * (total / 5000);
                    }
                    else if (total > 5000)
                    {
                        billetes[2] = billetes[2] + 1;
                        total -= 5000;
                    }
                    else if (total % 2000 == 0)
                    {
                        billetes[3] = billetes[3] + (total / 2000);
                        total -= 2000 * (total / 2000);
                    }
                    else if (total > 2000)
                    {
                        billetes[3] = billetes[3] + 1;
                        total -= 2000;
                    }
                    cont++;
                    if (cont > 25)
                    {
                        total = 0;
                        huboproblemas = true;
                    }
                }
                if (huboproblemas)
                {
                    Console.WriteLine("La cantidad no se puede dispensar, solo si se puede dispensar con billetes de:\n\t20mil\n\t10mil\n\t5mil\n\t2mil\n");
                    salidaCompleta += amount + "falló\n";
                }
                else
                {
                    Console.WriteLine("Desglose de Billetes\n");
                    Console.WriteLine("Billetes de 20mil: " + billetes[0]);
                    Console.WriteLine("Billetes de 10mil: " + billetes[1]);
                    Console.WriteLine("Billetes de 5mil: " + billetes[2]);
                    Console.WriteLine("Billetes de 2mil: " + billetes[3]);
                    capital -= amount;
                    salidaCompleta += amount + "Funciono\n";
                }
            }
            else
                Console.WriteLine("No se puede retirar no existen fondos");
        }
        //-3
        static void recibir_monedas() {
            string denominacion = "";
            int cont = 0;
            int monedas5 = 0;
            int monedas10 = 0;
            int monedas25 = 0;
            int monedas50 = 0;
            int monedas100 = 0;
            int monedas500 = 0;
            while (cont < 50)
            {
            //continuar:
                try
                {
                    Console.WriteLine("Ingrese <reporte> para ver el desglose\nFaltan {0} para terminar\nIngrese la denominacion <5,10,25,50,100,500> : ",50-cont);
                    denominacion = Console.ReadLine();
                    int toAdd = 0;
                    //monedas de 5
                    if (denominacion.Equals("5"))
                    {
                        Console.WriteLine("Ingrese cantidad de monedas de {0} : ", denominacion);
                        toAdd += int.Parse(Console.ReadLine());
                        if (cont + toAdd > 50)
                        {
                            Console.WriteLine("No se puede pasar de 50 monedas por transacción\nActualmente tiene: " + cont + " monedas");
                        }
                        else
                        {
                            cont += toAdd;
                            monedas5 += toAdd;
                            Console.WriteLine(monedas5);
                        }
                    }
                    //monedas de 10
                    else if (denominacion.Equals("10"))
                    {
                        Console.WriteLine("Ingrese cantidad de monedas de {0} : ", denominacion);
                        toAdd += int.Parse(Console.ReadLine());
                        if (cont + toAdd > 50)
                        {
                            Console.WriteLine("No se puede pasar de 50 monedas por transacción\nActualmente tiene: " + cont + " monedas");
                        }
                        else
                        {
                            cont += toAdd;
                            monedas10 += toAdd;
                            Console.WriteLine(monedas10);
                        }
                    }
                    //monedas de 25
                    else if (denominacion.Equals("25"))
                    {
                        Console.WriteLine("Ingrese cantidad de monedas de {0} : ", denominacion);
                        toAdd += int.Parse(Console.ReadLine());
                        if (cont + toAdd > 50)
                        {
                            Console.WriteLine("No se puede pasar de 50 monedas por transacción\nActualmente tiene: " + cont + " monedas");
                        }
                        else
                        {
                            cont += toAdd;
                            monedas25 += toAdd;
                            Console.WriteLine(monedas25);
                        }
                    }
                    //monedas de 50
                    else if (denominacion.Equals("50"))
                    {
                        Console.WriteLine("Ingrese cantidad de monedas de {0} : ", denominacion);
                        toAdd += int.Parse(Console.ReadLine());
                        if (cont + toAdd > 50)
                        {
                            Console.WriteLine("No se puede pasar de 50 monedas por transacción\nActualmente tiene: " + cont + " monedas");
                        }
                        else
                        {
                            cont += toAdd;
                            monedas50 += toAdd;
                            Console.WriteLine(monedas50);
                        }
                    }
                    //monedas de 100
                    else if (denominacion.Equals("100"))
                    {
                        Console.WriteLine("Ingrese cantidad de monedas de {0} : ", denominacion);
                        toAdd += int.Parse(Console.ReadLine());
                        if (cont + toAdd > 50)
                        {
                            Console.WriteLine("No se puede pasar de 50 monedas por transacción\nActualmente tiene: " + cont + " monedas");
                        }
                        else
                        {
                            cont += toAdd;
                            monedas100 += toAdd;
                            Console.WriteLine(monedas100);
                        }
                    }
                    // monedas de 500
                    else if (denominacion.Equals("500"))
                    {
                        Console.WriteLine("Ingrese cantidad de monedas de {0} : ", denominacion);
                        toAdd += int.Parse(Console.ReadLine());
                        if (cont + toAdd > 50)
                        {
                            Console.WriteLine("No se puede pasar de 50 monedas por transacción\nActualmente tiene: "+cont+" monedas");
                        }
                        else
                        {
                            cont += toAdd;
                            monedas500 += toAdd;
                            Console.WriteLine(monedas500);
                        }
                    }
                    // termina MONEDAS
                    else if (denominacion.ToLower().Equals("reporte"))
                    {
                        reporte_monedas_expedito(monedas5, monedas10, monedas25, monedas50, monedas100, monedas500, cont);
                        reporte_monedas_factura(monedas5, monedas10, monedas25, monedas50, monedas100, monedas500, cont);                        
                    }
                    else
                    {
                        Console.WriteLine("La denominación no es correcta");
                    }
                }
                catch (System.Exception e)
                {
                    Console.WriteLine("\nERROR " + e.Message + "\n");
                }
            }
            if (cont == 50)
	        {
                reporte_monedas_factura(monedas5,monedas10, monedas25, monedas50, monedas100,monedas500,cont);
                capital += (monedas5 * 5 + monedas10 * 10 + monedas25 * 25 + monedas50 * 50 + monedas100 * 100 + monedas500 * 500);
	        }
        }
        //-4
        static void indicar_tipodecambio() {
            Console.WriteLine("Ingrese: \n1- Dolares -> Colones\n2- Colones -> Dolares");
            try
            {
                int amount = 0;
                DateTime date = DateTime.Now;                
                string selec = Console.ReadLine();
                if (selec.Equals("1"))
                {
                    Console.Write("Ingrese la cantidad de Dolares para pasarlos a Colones: ");
                    amount = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n" + amount + " USD son: " + (amount * USD).ToString("N0") + " CRC");
                    Console.WriteLine(date.ToString("MM/dd/yyyy HH:mm\n---------------------------\n"));  
                }
                else if (selec.Equals("2"))
                { 
                    Console.Write("Ingrese la cantidad de Colones para pasarlos a Dolares: ");
                    amount = int.Parse(Console.ReadLine());
                    Console.WriteLine("\n" + amount + " CRC son: " + Math.Round(amount / USD, 2).ToString("N0") + " USD");
                    Console.WriteLine(date.ToString("MM/dd/yyyy HH:mm\n---------------------------"));
                }
                else
                    Console.WriteLine("Error opcion incorrecta");
            }
            catch (System.Exception e)
            {
                Console.WriteLine("\nERROR " + e.Message + "\n");
            }
        }

        static void reporte_monedas_expedito(int mon5, int mon10, int mon25, int mon50, int mon100, int mon500, int total) {
            Console.WriteLine("{0} - Monedas de 5\n{1} - Monedas de 10\n{2} - Monedas de 25\n{3} - Monedas de 50\n{4} - Monedas de 100\n{5} - Monedas de 500\nTotal Monedas: {6}", 
                mon5, mon10, mon25, mon50, mon100, mon500, total);
            int tot = mon5 * 5 + mon10 * 10 + mon25 * 25 + mon50 * 50 + mon100 * 100 + mon500 * 500;
            Console.WriteLine("Total : " + tot);
        }

        static void reporte_monedas_factura(int mon5, int mon10, int mon25, int mon50, int mon100, int mon500, int total)

        {
            Console.WriteLine("Monedas\tCantidad\tTotal\n");
            Console.WriteLine("5\t"+      mon5 + "\t\t"      +mon5 * 5);
            Console.WriteLine("10\t" + mon10 + "\t\t" + mon10 * 10);
            Console.WriteLine("25\t" + mon25 + "\t\t" + mon25 * 25);
            Console.WriteLine("50\t" + mon50 + "\t\t" + mon50 * 50);
            Console.WriteLine("100\t" + mon100 + "\t\t" + mon100 * 100);
            Console.WriteLine("500\t" + mon500 + "\t\t" + mon500 * 500);
            int tot = mon5 * 5 + mon10 * 10 + mon25 * 25 + mon50 * 50 + mon100 * 100 + mon500 * 500;
            Console.WriteLine("Total : " + tot);
        }

        #region
        //static void retirar_dinero(int amount,string original)
        //{
        //    int total = amount;
        //    List<int> billetes = new List<int>(new int[] { 0, 0, 0, 0 });
        //    bool huboproblemas = false;
        //    int cont = 0;
        //    int miles = 0;

        //    if (capital > 0 && capital >= amount)
        //    {
        //        while (total > 0)
        //        {
        //            if (original.Length > 4)
        //            {
        //                miles = int.Parse(original.Substring(1, 4));
        //                //casos que no se puede dispensar
        //                if (miles == 1000)
        //                {
        //                    huboproblemas = true;
        //                    total = 0;
        //                }
        //                if (miles == 3000)
        //                {
        //                    huboproblemas = true;
        //                    total = 0;
        //                }
        //                if (miles == 5000)
        //                {
        //                    huboproblemas = true;
        //                    total = 0;
        //                }
        //                //buenas
        //                if (miles == 2000)
        //                {
        //                    billetes[3]++;
        //                    total -= 2000;
        //                }
        //                if (miles == 4000)
        //                {
        //                    billetes[3] += 2;
        //                    total -= 4000;
        //                }
        //                if (miles == 6000)
        //                {
        //                    billetes[3] += 3;
        //                    total -= 60000;
        //                }
        //                if (miles == 8000)
        //                {
        //                    billetes[3] += 4;
        //                    total -= 8000;
        //                }
        //                if (miles == 7000)
        //                {
        //                    //1 de 2mil
        //                    billetes[3] += 1;
        //                    //1 de 5mil
        //                    billetes[2] += 1;
        //                    total -= 7000;
        //                }
        //                if (miles == 9000)
        //                {
        //                    //1 de 5mil
        //                    billetes[2] += 1;
        //                    //2 de 2 mil
        //                    billetes[3] += 2;
        //                    total -= miles;
        //                }

        //            }
        //            else {
        //                if (total % 20000 == 0)
        //                {
        //                    billetes[0] = billetes[0] + (total / 20000);
        //                    total -= 20000 * (total / 20000);
        //                }
        //                else if (total > 20000)
        //                {
        //                    billetes[0] = billetes[0] + 1;
        //                    total -= 20000;
        //                }
        //                else if (total % 10000 == 0)
        //                {
        //                    billetes[1] = billetes[1] + (total / 10000);
        //                    total -= 10000 * (total / 10000);
        //                }
        //                else if (total > 10000)
        //                {
        //                    billetes[1] = billetes[1] + 1;
        //                    total -= 10000;
        //                }
        //                else if (total % 5000 == 0)
        //                {
        //                    billetes[2] = billetes[2] + (total / 5000);
        //                    total -= 5000 * (total / 5000);
        //                }
        //                else if (total > 5000)
        //                {
        //                    billetes[2] = billetes[2] + 1;
        //                    total -= 5000;
        //                }
        //                else if (total % 2000 == 0)
        //                {
        //                    billetes[3] = billetes[3] + (total / 2000);
        //                    total -= 2000 * (total / 2000);
        //                }
        //                else if (total > 2000)
        //                {
        //                    billetes[3] = billetes[3] + 1;
        //                    total -= 2000;
        //                } 
        //            }
                    
        //            cont++;
        //            if (cont > 25)
        //            {
        //                total = 0;
        //                huboproblemas = true;
        //            }
        //        }
        //        if (huboproblemas)
        //        {
        //            Console.WriteLine("La cantidad no se puede dispensar, solo si se puede dispensar con billetes de:\n\t20mil\n\t10mil\n\t5mil\n\t2mil\n");
        //            salidaCompleta += amount + "falló\n";
        //        }
        //        else
        //        {
        //            Console.WriteLine("Desglose de Billetes\n");
        //            Console.WriteLine("Billetes de 20mil: " + billetes[0]);
        //            Console.WriteLine("Billetes de 10mil: " + billetes[1]);
        //            Console.WriteLine("Billetes de 5mil: " + billetes[2]);
        //            Console.WriteLine("Billetes de 2mil: " + billetes[3]);
        //            capital -= amount;
        //            salidaCompleta += amount + "Funciono\n";
        //        }
        //    }
        //    else
        //        Console.WriteLine("No se puede retirar no existen fondos");
        //}

        ////static void retirar_dinero(int amount) {
        ////    int total = amount;
        ////    List<int> billetes = new List<int>(new int[] { 0,0,0,0 });
        ////    bool huboproblemas = false;
        ////    int cont = 0;
        ////    if (capital > 0 && capital >= amount)
        ////    {
        ////    while (total > 0)
        ////    {
        ////        if (total >= 20000)
        ////        {
        ////            Console.Write("20000 ");
        ////            total -= 20000;
        ////            billetes[0]++;
        ////        }
        ////        else
        ////        {
        ////            if (total >= 10000)
        ////            {
        ////                Console.Write("10000 ");
        ////                total -= 10000;
        ////                billetes[1]++;
        ////            }
        ////            else
        ////            {
        ////                if (total >= 5000)
        ////                {
        ////                    Console.Write("5000 ");
        ////                    total -= 5000;
        ////                    billetes[2]++;
        ////                }
        ////                else
        ////                {
        ////                    if (total >= 2000)
        ////                    {
        ////                        Console.Write("2000 ");
        ////                        total -= 2000;
        ////                        billetes[3]++;
        ////                    }                                                        
        ////                }
        ////            }
        ////        }
        ////        cont++;
        ////        if (cont > 25)
        ////        {
        ////            total = 0;
        ////            huboproblemas = true;
        ////        }
        ////    }
        ////    if (huboproblemas)
        ////    {
        ////        Console.WriteLine("La cantidad no se puede dispensar, solo si se puede dispensar con billetes de:\n\t20mil\n\t10mil\n\t5mil\n\t2mil\n");
        ////        salidaCompleta += amount + "falló\n";
        ////    }
        ////    else { 
        ////    Console.WriteLine("Desglose de Billetes\n");
        ////        Console.WriteLine("Billetes de 20mil: "+ billetes[0]);
        ////        Console.WriteLine("Billetes de 10mil: "+ billetes[1]);
        ////        Console.WriteLine("Billetes de 5mil: " + billetes[2]);
        ////        Console.WriteLine("Billetes de 2mil: " + billetes[3]);
        ////        capital -= amount;
        ////        salidaCompleta += amount + "Funciono\n";
        ////    }

        ////    }
        ////    else
        ////        Console.WriteLine("No se puede retirar no existen fondos");
        
        ////}

        //static void retirar_dinero(int amount)
        //{
        //    int total = amount;
        //    List<int> billetes = new List<int>(new int[] { 0, 0, 0, 0 });
        //    bool huboproblemas = false;
        //    int cont = 0;

        //    if (capital > 0 && capital >= amount)
        //    {
        //        while (total > 0)
        //        {
        //            //Console.WriteLine("entro al while");
        //            if (total > 20000)
        //            {
        //                billetes[0] = billetes[0] + 1;
        //                total -= 20000;
        //            }
        //            else if (total % 20000 == 0)
        //            {
        //                billetes[0] = billetes[0] + (total / 20000);
        //                total -= 20000 * (total / 20000);
        //            }
        //            else if (total % 10000 == 0)
        //            {
        //                billetes[1] = billetes[1] + (total / 10000);
        //                total -= 10000 * (total / 10000);
        //            }
        //            else if (total > 10000)
        //            {
        //                billetes[1] = billetes[1] + 1;
        //                total -= 10000;
        //            }
        //            else if (total % 5000 == 0)
        //            {
        //                billetes[2] = billetes[2] + (total / 5000);
        //                total -= 5000 * (total / 5000);
        //            }
        //            else if (total > 5000)
        //            {
        //                billetes[2] = billetes[2] + 1;
        //                total -= 5000;
        //            }
        //            else if (total % 2000 == 0)
        //            {
        //                billetes[3] = billetes[3] + (total / 2000);
        //                total -= 2000 * (total / 2000);
        //            }
        //            else if (total > 2000)
        //            {
        //                billetes[3] = billetes[3] + 1;
        //                total -= 2000;
        //            }
        //            cont++;
        //            if (cont > 25)
        //            {
        //                total = 0;
        //                huboproblemas = true;
        //            }
        //        }
        //        if (huboproblemas)
        //        {
        //            Console.WriteLine("La cantidad no se puede dispensar, solo si se puede dispensar con billetes de:\n\t20mil\n\t10mil\n\t5mil\n\t2mil\n");
        //            salidaCompleta += amount + "falló\n";
        //        }
        //        else
        //        {
        //            Console.WriteLine("Desglose de Billetes\n");
        //            Console.WriteLine("Billetes de 20mil: " + billetes[0]);
        //            Console.WriteLine("Billetes de 10mil: " + billetes[1]);
        //            Console.WriteLine("Billetes de 5mil: " + billetes[2]);
        //            Console.WriteLine("Billetes de 2mil: " + billetes[3]);
        //            capital -= amount;
        //            salidaCompleta += amount + "Funciono\n";
        //        }
        //    }
        //    else
        //        Console.WriteLine("No se puede retirar no existen fondos");
        //}

        #endregion
        //Unit testing
        static void probar() {
            int x = 1000;
            for (int i = 0; i < 200; i++)
            {
                //retirar_dinero(x);
                x += 1000;
            }
            Console.WriteLine(salidaCompleta);
        }

        #endregion
        static void Webservice() {
            try
            {
                Console.WriteLine("Tipo cambio default era: " + USD +"\nAhora es: ");
                cr.fi.bccr.indicadoreseconomicos.wsIndicadoresEconomicos tp = new cr.fi.bccr.indicadoreseconomicos.wsIndicadoresEconomicos();
                var today = DateTime.Today.ToString("dd/M/yyyy");
                var yesterday = DateTime.Today.AddDays(-1);
                DataSet ds = tp.ObtenerIndicadoresEconomicos("317", yesterday.ToString("dd/M/yyyy"), today, "PCP", "N");
                string s = ds.Tables[0].Rows[1].ItemArray[2].ToString();
                Console.WriteLine(s);
                USD = double.Parse(s);
                USD = Math.Round(USD, 2);
            }
            catch (System.Exception e)
            {
                Console.WriteLine("\nERROR " + e.Message + "\n");
            }
        }
    }
}
