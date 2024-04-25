using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A2_2324
{
    internal class Testing
    {
        List<string> logLines = new List<string>();
        public void RunTests()
        {
            logLines.Clear();
            logLines.Add($"----Start Tests [{DateTime.Now}]----");
            TestDiceSum();
            TestContinuePlaying();
            TestAddScore();
            TestIsGameOver();
            logLines.Add($"----End Tests [{DateTime.Now}]----");
            WriteToLog(logLines.ToArray());
        }
        private void TestDiceSum()
        {
            SevensOut sevens = new SevensOut();
            sevens.dice[0].currentValue = 2;
            sevens.dice[1].currentValue = 5;
            int correctSum = 7;
            int testSum = sevens.GetDiceSum();

            bool testResult = testSum == correctSum;
            Debug.Assert(testResult, "The dice is not summed correctly.");
            logLines.Add($"TestDiceSum(): {(testResult ? "Pass" : "Fail")}");
        }

        private void TestContinuePlaying()
        {
            SevensOut sevens = new SevensOut();

            // Test for continue playing
            sevens.dice[0].currentValue = 5;
            sevens.dice[1].currentValue = 6;
            bool correctBool = true;
            bool testBool = sevens.ContinuePlaying();
            bool testResult = correctBool == testBool;
            Debug.Assert(testResult, "The game stops when the game should continue.");
            logLines.Add($"TestContinuePlaying() Keep Playing: {(testResult ? "Pass" : "Fail")}");
            // Test for stopping play
            sevens.dice[0].currentValue = 3;
            sevens.dice[1].currentValue = 4;
            correctBool = false;
            testBool = sevens.ContinuePlaying();
            testResult = correctBool == testBool;
            Debug.Assert(testResult, "The game continues when the game should stop.");
            logLines.Add($"TestContinuePlaying() Stop Playing: {(testResult ? "Pass" : "Fail")}");
        }
        private void TestAddScore()
        {
            ThreeOrMore three = new();

            // Test 1 of a kind score
            int correctScore = 0;
            int testScore = three.AddScore(true, 1);
            bool testResult = correctScore == testScore;
            Debug.Assert(testResult, "1 of a kind doesn't give 0 score.");
            logLines.Add($"TestAddScore() 1-of-a-kind: {(testResult ? "Pass" : "Fail")}");

            // Test 2 of a kind score
            correctScore = 0;
            testScore = three.AddScore(true, 2);
            testResult = correctScore == testScore;
            Debug.Assert(testResult, "2 of a kind doesn't give 0 score.");
            logLines.Add($"TestAddScore() 2-of-a-kind: {(testResult ? "Pass" : "Fail")}");

            // Test 3 of a kind score
            correctScore = 3;
            testScore = three.AddScore(true, 3);
            testResult = correctScore == testScore;
            Debug.Assert(testResult, "3 of a kind doesn't give 3 score.");
            logLines.Add($"TestAddScore() 3-of-a-kind: {(testResult ? "Pass" : "Fail")}");

            // Test 4 of a kind score
            correctScore = 6;
            testScore = three.AddScore(true, 4);
            testResult = correctScore == testScore;
            Debug.Assert(testResult, "4 of a kind doesn't give 6 score.");
            logLines.Add($"TestAddScore() 4-of-a-kind: {(testResult ? "Pass" : "Fail")}");

            // Test 5 of a kind score
            correctScore = 12;
            testScore = three.AddScore(true, 5);
            testResult = correctScore == testScore;
            Debug.Assert(testResult, "5 of a kind doesn't give 12 score.");
            logLines.Add($"TestAddScore() 5-of-a-kind: {(testResult ? "Pass" : "Fail")}");
        }

        private void TestIsGameOver()
        {
            ThreeOrMore three = new();

            // Test P1 < 20, P2 < 20
            three.p1Score = 19;
            three.p2Score = 18;
            bool correctBool = false;
            bool testBool = three.IsGameOver();
            bool testResult = correctBool == testBool;
            Debug.Assert(testResult, "Game ends when it is not supposed to.");
            logLines.Add($"TestIsGameOver() P1 < 20, P2 < 20: {(testResult ? "Pass" : "Fail")}");
            // Test P1 = 20, P2 < 20
            three.p1Score = 20;
            three.p2Score = 18;
            correctBool = true;
            testBool = three.IsGameOver();
            testResult = correctBool == testBool;
            Debug.Assert(testResult, "Game continues when it is supposed to end.");
            logLines.Add($"TestIsGameOver() P1 = 20, P2 < 20: {(testResult ? "Pass" : "Fail")}");
            // Test P1 < 20, P2 = 20
            three.p1Score = 6;
            three.p2Score = 20;
            correctBool = true;
            testBool = three.IsGameOver();
            testResult = correctBool == testBool;
            Debug.Assert(testResult, "Game continues when it is supposed to end.");
            logLines.Add($"TestIsGameOver() P1 < 20, P2 = 20: {(testResult ? "Pass" : "Fail")}");
            // Test P1 > 20, P2 < 20
            three.p1Score = 25;
            three.p2Score = 6;
            correctBool = true;
            testBool = three.IsGameOver();
            testResult = correctBool == testBool;
            Debug.Assert(testResult, "Game continues when it is supposed to end.");
            logLines.Add($"TestIsGameOver() P1 > 20, P2 < 20: {(testResult ? "Pass" : "Fail")}");
            // Test P1 < 20, P2 > 20
            three.p1Score = 5;
            three.p2Score = 26;
            correctBool = true;
            testBool = three.IsGameOver();
            testResult = correctBool == testBool;
            Debug.Assert(testResult, "Game continues when it is supposed to end.");
            logLines.Add($"TestIsGameOver() P1 < 20, P2 > 20: {(testResult ? "Pass" : "Fail")}");
        }

        private void WriteToLog(string[] lines)
        {
            using (StreamWriter outputFile = File.AppendText("TestLog.txt"))
            {
                foreach (string line in lines)
                {
                    outputFile.WriteLine(line);
                }
            }
        }

        
    }
}
