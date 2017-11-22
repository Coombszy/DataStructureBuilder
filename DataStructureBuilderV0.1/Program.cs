using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataStructureBuilderV0._1
{
    class Program
    {
        static void Main(string[] args)
        {
            HeaderNode DataStructure = new HeaderNode();
            //HeaderNode.WriteArray(HeaderNode.HeadArray);

            //----------------------- WORKING METHOD TO TRANSVERSE DAC -----------------------
            /*
            Console.WriteLine("------------------------------------");
            DataStructure.BuildWord("ABC");
            DataStructure.BuildWord("ABZC");
            Node Test1 = (Node)(DataStructure.HeadArray[0]); //Jumps to Node A
            Node Test2 = (Node)(Test1.MyChildArray[1]); //Jumps to Node A-B (Child Of A)
            Node Test3 = (Node)(Test2.MyChildArray[2]); //Jumps to Node A-B-C (Child Of B, Which is Child Of A)

            Node Test4 = (Node)(Test2.MyChildArray[25]); //Jumps to Node A-B-Z
            Node Test5 = (Node)(Test4.MyChildArray[2]); //Jumps to Node A-B-Z-C
            Console.WriteLine(Test1.MyValue+ Test2.MyValue+ Test3.MyValue);
            Console.WriteLine(Test1.MyValue + Test2.MyValue + Test4.MyValue + Test5.MyValue);
            Console.ReadLine();
            Console.Clear();*/

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ReadLine();
            Console.WriteLine("BUILDING DAC OF 'WordList.txt'");
            var fdata = File.ReadAllLines("Data/WordList.txt");
            for (int i = 0; i < fdata.Length; i++)
            {
                DataStructure.BuildWord(fdata[i]);
            }
            Console.WriteLine("-Complete!");

            Console.ReadLine();

        }
    }
    class HeaderNode
    {
        public object[] HeadArray = new object[26];
        public HeaderNode()
        {
            CreateChildNodes();
        }
        private void CreateChildNodes()
        {
            for (int i = 0; i < 26; i++)
            {
                HeadArray[i] = new Node(""+Convert.ToChar(65+i));
            }
        }
        public static void WriteArray(object[] array)
        {
            foreach (object element in array)
            {
                if (element != null)
                {
                    Console.WriteLine(element.ToString());
                    Console.WriteLine(element.GetType());
                    Console.WriteLine("---");
                }
            }
        }
        public void BuildWord(string Word)
        {
            Word = Word.ToUpper();
            int location = Word[0]-65;
            Word = Word.Remove(0,1);
            Node Child = (Node)HeadArray[location];
            Child.BuildWord(Word);
        }
    }
    class Node
    {
        public string MyValue;
        public object[] MyChildArray = new object[26];
        public Node(string Letter)
        {
            MyValue = Letter;
        }
        public void BuildWord(string Word)
        {
            if (Word != "")
            {
                int TargetLocation = (int)Word[0] - 65;
                if (MyChildArray[TargetLocation] == null)
                {
                    MyChildArray[TargetLocation] = new Node("" + Convert.ToChar(Word[0]));
                }
                Word = Word.Remove(0, 1);
                Node Child = (Node)MyChildArray[TargetLocation];
                Child.BuildWord(Word);
            }
        }
    }
}
