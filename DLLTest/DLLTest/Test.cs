﻿using System;
using UnityEngine;

namespace DLLTest
{
    public class Test
    {
        public int c;

        public void AddValues(int a, int b)
        {
            c = a + b;
        }

        public static int GenerateRandom(int min, int max)
        {
            System.Random rand = new System.Random();
            return rand.Next(min, max);
        }
    }
}

namespace DLLTest.Emre
{
    public class Emre
    {

    }
}
