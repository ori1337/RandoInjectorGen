using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TestProjectaaaaaIMGAYNOOB
{
    class Program
    {
        static Random random = new Random();

        static void Main()
        {
            File.WriteAllText("RandoInjector\\Main.cpp", String.Empty);
            //int[] HowMuchLinesDoYouWant = new int[5];//the int it's the count of lines    /////NOT IN USE ANYMOAR :( 


            Console.WriteLine("Hello my friend");
            Console.WriteLine("This software made by chess123virus, and i happy you use it !");
            Console.WriteLine("");
            Console.WriteLine("Well How much lines do you want In the \"__asm _emit\" ?! ");
            Console.WriteLine("If you ask me ? i use 350 lines :D but you can put much as you want..");
            int HowMuchLinesDoYouWantIntUseInput = Convert.ToInt32(Console.ReadLine());
            int[] HowMuchLinesDoYouWant = new int[HowMuchLinesDoYouWantIntUseInput];//the int it's the count of lines

            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter("RandoInjector\\Main.cpp", true);

                #region
                file.WriteLine("#include <iostream>");
                file.WriteLine("#include <Windows.h>");
                file.WriteLine("#include <TlHelp32.h>");
                file.WriteLine("");
                file.WriteLine("#define DLL_NAME \"cheat.dll\"");
                file.WriteLine("");
                file.WriteLine("#define JUNKS \\");
                #endregion


                foreach (int i in HowMuchLinesDoYouWant)
                {
                    file.WriteLine("__asm _emit 0x" + GetRandomHexNumber(2).ToString() + " \\");
                }//Wirte some {__asm _emit $HexRandom$ \} in the output to make the injector undetected DDAAAA



                //-------
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("#define _JUNK_BLOCK(s) __asm jmp s JUNKS __asm s:");// i put it here becuase it is looks good inside my head 

                #region
                //Start 2 wirte shit function
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("");
                file.WriteLine("DWORD Process(char* ProcessName)");
                file.WriteLine("{");
                file.WriteLine("	_JUNK_BLOCK(jmp_label1)");
                file.WriteLine("	HANDLE hPID = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, NULL);");
                file.WriteLine("	");
                file.WriteLine("	_JUNK_BLOCK(jmp_label2)");
                file.WriteLine("	PROCESSENTRY32 ProcEntry;");
                file.WriteLine("	");
                file.WriteLine("	_JUNK_BLOCK(jmp_label3)");
                file.WriteLine("	ProcEntry.dwSize = sizeof(ProcEntry);");
                file.WriteLine("	");
                file.WriteLine("	_JUNK_BLOCK(jmp_label4)");
                file.WriteLine("	do");
                file.WriteLine("	{");
                file.WriteLine("		_JUNK_BLOCK(jmp_label5)");
                file.WriteLine("		if (!strcmp(ProcEntry.szExeFile, ProcessName))");
                file.WriteLine("		{");
                file.WriteLine("			_JUNK_BLOCK(jmp_label6)");
                file.WriteLine("			DWORD dwPID = ProcEntry.th32ProcessID;");
                file.WriteLine("			");
                file.WriteLine("			_JUNK_BLOCK(jmp_label7)");
                file.WriteLine("			CloseHandle(hPID);");
                file.WriteLine("			");
                file.WriteLine("			_JUNK_BLOCK(jmp_label8)");
                file.WriteLine("			return dwPID;");
                file.WriteLine("		}");
                file.WriteLine("		");
                file.WriteLine("		_JUNK_BLOCK(jmp_label9)");
                file.WriteLine("	}");
                file.WriteLine("	while (Process32Next(hPID, &ProcEntry));");
                file.WriteLine("	");
                file.WriteLine("	_JUNK_BLOCK(jmp_label10)");
                file.WriteLine("}");
                file.WriteLine("");
                file.WriteLine("int main()");
                file.WriteLine("{");
                file.WriteLine("	_JUNK_BLOCK(jmp_label11)");
                file.WriteLine("	DWORD dwProcess;");
                file.WriteLine("	");
                file.WriteLine("	_JUNK_BLOCK(jmp_label12)");
                file.WriteLine("	char myDLL[MAX_PATH];");
                file.WriteLine("	");
                file.WriteLine("	_JUNK_BLOCK(jmp_label13)");
                file.WriteLine("	GetFullPathName(DLL_NAME, MAX_PATH, myDLL, 0);");
                file.WriteLine("	");
                file.WriteLine("	_JUNK_BLOCK(jmp_label4)");
                file.WriteLine("	dwProcess = Process(\"csgo.exe\");");
                file.WriteLine("	");
                file.WriteLine("	_JUNK_BLOCK(jmp_label15)");
                file.WriteLine("	HANDLE hProcess = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_READ | PROCESS_VM_WRITE | PROCESS_VM_OPERATION, FALSE, dwProcess);");
                file.WriteLine("	");
                file.WriteLine("	_JUNK_BLOCK(jmp_label16)");
                file.WriteLine("	LPVOID allocatedMem = VirtualAllocEx(hProcess, NULL, sizeof(myDLL), MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);");
                file.WriteLine("	");
                file.WriteLine("	_JUNK_BLOCK(jmp_label17)");
                file.WriteLine("	WriteProcessMemory(hProcess, allocatedMem, myDLL, sizeof(myDLL), NULL);");
                file.WriteLine("	");
                file.WriteLine("	_JUNK_BLOCK(jmp_label18)");
                file.WriteLine("	CreateRemoteThread(hProcess, 0, 0, (LPTHREAD_START_ROUTINE)LoadLibrary, allocatedMem, 0, 0);");
                file.WriteLine("	");
                file.WriteLine("	_JUNK_BLOCK(jmp_label19)");
                file.WriteLine("	CloseHandle(hProcess);");
                file.WriteLine("	");
                file.WriteLine("	_JUNK_BLOCK(jmp_label20)");
                file.WriteLine("	return 0;");
                file.WriteLine("	");
                file.WriteLine("	_JUNK_BLOCK(jmp_label21)");
                file.WriteLine("}");
                //Done Wirte shit into a file 
                file.Close();//Close the connection to the file
                #endregion
            }
            catch (Exception e) { }
            Console.Write("Press <Enter> to exit..." +
                "\n (i like dildos)" +
                "\n now a bit seriousness :D" +
                "\n Credits:" +
                "\n   @netspider to be a good guy :D" +
                "\n   @Wlan" +
                "\n   And the biggest thanks is going to #RandoInjectMaker and his helpers/resource" +
                "\n\n   credit to google Too XD" +
                "\n TO EXIT PRESS [ENTER] ");

            while (Console.ReadKey().Key != ConsoleKey.Enter) { }

        }


        public static string GetRandomHexNumber(int digits)
        {
            byte[] buffer = new byte[digits / 2];
            random.NextBytes(buffer);
            string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
            if (digits % 2 == 0)
            {
                return result;
            }
            return result + random.Next(16).ToString("X");
        }
    }
}
