﻿using System;

namespace aernautica_imperiali {
    public class Dice {
        private static Dice _instance = new Dice();

        private Random _random = new Random();

        private Dice() {
        }

        public static Dice GetInstance() {
            return _instance;
        }


        public int Roll() {
            return _random.Next(1, 7);
        }
    }
}