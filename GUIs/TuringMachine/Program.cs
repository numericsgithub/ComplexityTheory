using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{

    /// <summary>
    ///  Abschätzung laufzeit, übergangsfunktion
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            new MainForm().ShowDialog();
//            List<Band> baender = new List<Band>();
//            baender.Add(new Band(TouringParser.ReadBandContent("(☐,1,1,0,1)")));
//            baender.Add(new Band());
//            baender.Add(new Band());

//            List<MoveFunktion> funcs = TouringParser.ParseMoveFunctions("start(☐,☐,☐) -> q1(☐,☐)(>,>,>) \r\n" +
//"q1(1,☐,☐) -> q1(1,☐)(>,>,-)    \r\n" +
//"q1(0,☐,☐) -> q1(0,☐)(>,>,-)    \r\n" +
//"q1(☐,☐,☐) -> q2(☐,☐)(-,<,-)    \r\n" +
//"q2(☐,1,☐) -> q2(1,☐)(-,<,-)    \r\n" +
//"q2(☐,0,☐) -> q2(0,☐)(-,<,-)    \r\n" +
//"q2(☐,☐,☐) -> q3(☐,☐)(<,>,-)    \r\n" +
//"q3(1,1,☐) -> q3(1,☐)(<,>,-)    \r\n" +
//"q3(0,0,☐) -> q3(0,☐)(<,>,-)    \r\n" +
//"q3(1,0,☐) -> end(0,0)(-,-,-)   \r\n" +
//"q3(0,1,☐) -> end(1,0)(-,-,-)   \r\n" +
//"q3(☐,☐,☐) -> end(☐,1)(-,-,-)   \r\n").ToList();
            //funcs.Add(new MoveFunktion("start", new List<char>() { Char.Start, Char.Start, Char.Start },
            //                            "q1", new List<char>() { Char.Start, Char.Start },
            //                            new List<Direction>() { Direction.Right, Direction.Right, Direction.Right }));

            //// Move to the right
            //funcs.Add(new MoveFunktion("q1", new List<char>() { Char.One, Char.Empty, Char.Empty },
            //                            "q1", new List<char>() { Char.One, Char.Empty },
            //                            new List<Direction>() { Direction.Right, Direction.Right, Direction.Stay }));

            //funcs.Add(new MoveFunktion("q1", new List<char>() { Char.Zero, Char.Empty, Char.Empty },
            //                            "q1", new List<char>() { Char.Zero, Char.Empty },
            //                            new List<Direction>() { Direction.Right, Direction.Right, Direction.Stay }));

            //// Am Ende Angekommen
            //funcs.Add(new MoveFunktion("q1", new List<char>() { Char.Empty, Char.Empty, Char.Empty },
            //                            "q2", new List<char>() { Char.Empty, Char.Empty },
            //                            new List<Direction>() { Direction.Stay, Direction.Left, Direction.Stay }));

            //// Nach Links rücken
            //funcs.Add(new MoveFunktion("q2", new List<char>() { Char.Empty, Char.One, Char.Empty },
            //                            "q2", new List<char>() { Char.One, Char.Empty },
            //                            new List<Direction>() { Direction.Stay, Direction.Left, Direction.Stay }));

            //funcs.Add(new MoveFunktion("q2", new List<char>() { Char.Empty, Char.Zero, Char.Empty },
            //                            "q2", new List<char>() { Char.Zero, Char.Empty },
            //                            new List<Direction>() { Direction.Stay, Direction.Left, Direction.Stay }));

            //// Rechts angekommen
            //funcs.Add(new MoveFunktion("q2", new List<char>() { Char.Empty, Char.Start, Char.Empty },
            //                            "q3", new List<char>() { Char.Start, Char.Empty },
            //                            new List<Direction>() { Direction.Left, Direction.Right, Direction.Stay }));

            //// Prüfen
            //funcs.Add(new MoveFunktion("q3", new List<char>() { Char.One, Char.One, Char.Empty },
            //                            "q3", new List<char>() { Char.One, Char.Empty },
            //                            new List<Direction>() { Direction.Left, Direction.Right, Direction.Stay }));
            //// Prüfen
            //funcs.Add(new MoveFunktion("q3", new List<char>() { Char.Zero, Char.Zero, Char.Empty },
            //                            "q3", new List<char>() { Char.Zero, Char.Empty },
            //                            new List<Direction>() { Direction.Left, Direction.Right, Direction.Stay }));

            //// Prüfen ENDE
            //funcs.Add(new MoveFunktion("q3", new List<char>() { Char.One, Char.Zero, Char.Empty },
            //                            "end", new List<char>() { Char.Zero, Char.Zero },
            //                            new List<Direction>() { Direction.Stay, Direction.Stay, Direction.Stay }));
            //// Prüfen ENDE
            //funcs.Add(new MoveFunktion("q3", new List<char>() { Char.Zero, Char.One, Char.Empty },
            //                            "end", new List<char>() { Char.One, Char.Zero },
            //                            new List<Direction>() { Direction.Stay, Direction.Stay, Direction.Stay }));

            //// ERFOLG ENDE
            //funcs.Add(new MoveFunktion("q3", new List<char>() { Char.Start, Char.Empty, Char.Empty },
            //                            "end", new List<char>() { Char.Empty, Char.One },
            //                            new List<Direction>() { Direction.Stay, Direction.Stay, Direction.Stay }));


            //TouringMachine machine = new TouringMachine(baender, funcs);
            //string s = machine.ToString();
            //while(true)
            //{
            //    machine.Print();
            //    Console.ReadLine();
            //    machine.PerformStep();
            //}
        }
    }
}
