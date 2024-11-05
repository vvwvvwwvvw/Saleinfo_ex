using System;
using System.Collections;
using System.Globalization;
namespace Saleinfo_ex
{
    //구조체
    struct saleinfo
    {
        public string cid; // 고객번호
        public string pid; // 상품 번호
        public int qty; // 판매수량
        public int amount; // 판매금액

    }
     class Program
    {
        //매출 등록 코드
        static void SaleSlip(saleinfo[] s)
        {
            Console.Write("날짜를 입력하세요(1~31)"); // 안내 메세지 출력
            int day = int.Parse(Console.ReadLine()); // 날짜 입력 받음
            if (0 < day && day < 32)
            { // 날짜 에러 체크
                Console.Write("고객명을 입력 하세요");
                s[day - 1].cid = Console.ReadLine();
                Console.Write("상품명을 입력 하세요");
                s[day - 1].pid = Console.ReadLine();
                Console.Write("수량을입력 하세요");
                s[day - 1].qty = int.Parse(Console.ReadLine());
                Console.Write("금액을 입력 하세요");
                s[day - 1].amount = int.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("잘못된 날짜 입력입니다");
            }
        }
        //고객별 매출액 정리
        static void CustomerSummary(saleinfo[] s)
        {
            Hashtable summarytable = new Hashtable();
            for (int i = 0; i < 31; i++)
            {
                string key = s[i].cid;
                if (key == null)
                {
                    continue;
                }
                else if (summarytable.ContainsKey(key)) // 고객 이름이 등록되어있으면 기존 매출에 더함
                {
                    summarytable[key] = (int)summarytable[key] + s[i].amount;
                }
                else // 고객명이 없으면 현제 고객 명을 key로 하고 매출액을 value로 하여 table에 등록
                {
                    summarytable.Add(s[i].cid, s[i].amount);
                }
                foreach (DictionaryEntry cs in summarytable)
                {
                    Console.WriteLine("{0}:{1}", cs.Key, cs.Value);
                }
            }
        }
        //품목별 매출액 정리
        static void ItemSummary(saleinfo[] s)
        {
            Hashtable itemtable = new Hashtable();
            for (int i = 0; i < 31; i++)
            {
                string key = s[i].cid;
                if (key == null)
                {
                    continue;
                }
                else if (itemtable.ContainsKey(key)) 
                {
                    itemtable[key] = (int)itemtable[key] + s[i].amount;
                }
                else 
                {
                    itemtable.Add(s[i].cid, s[i].amount);
                }
                foreach (DictionaryEntry cs in itemtable)
                {
                    Console.WriteLine("{0}:{1}", cs.Key, cs.Value);
                }
            }
        }
        static void Main(string[] args)
        {
            saleinfo[] saledata = new saleinfo[31];
            while (true)
            {
                Console.WriteLine("#1= 매출 전표 입력, 2=고객별 월 매출, 3=상품별 월 매출, 0=프로그램 종료#");
                Console.Write("원하는 작업을 입력 하세요");
                int command = int.Parse(Console.ReadLine());//키보드 입력 받기
                if (command == 0) break; //입력값이 0이면 종료
                switch (command)
                {
                    case 1:
                        SaleSlip(saledata); // 입력값이 1이면 매출 입력
                        break;
                    case 2:
                        CustomerSummary(saledata); // 입력값이 2 이면 고객별 매출 정리
                        break;
                    case 3:
                        ItemSummary(saledata); // 입력값이 3이면 품목별 매출 정리
                        break;
                }
            }
        }
    }
}
