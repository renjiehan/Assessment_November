using System;
using System.Collections.Generic;
using System.Numerics;
using Open.Numeric.Primes;

namespace utilsApi;
public class EndPoints {
    // Consturctor
    EndPoints() {}
    static public List<long> primeNumbers(int listSize, int startFrom) {
        List<long> primes = new List<long>();

        if(listSize <= 0 || startFrom <= 0) return primes;

        foreach(var prime in Prime.Numbers.StartingAt(startFrom).Take(listSize))
        {
            primes.Add(prime);
        }

        return primes;
    }
    static public List<string> fibonacci(int listSize, int startFrom) {
        List<string> sequence = new List<string>();

        if(listSize <= 0 || startFrom <= 0) return sequence;

        BigInteger first = new BigInteger(0);
        BigInteger second = new BigInteger(1);
        BigInteger next = new BigInteger(0);
        BigInteger stop = new BigInteger(startFrom);

        while(next < stop) {
            next = first + second;
            first = second;
            second = next;
        }

        for(var i = 0; i < listSize; i++) {
            next = first + second;
            first = second;
            second = next;

            sequence.Add(next.ToString("N0").Replace(",", ""));
        }

        return sequence;
    }
    static public List<char> RandomChars(int listSize, int seed) {
        if(listSize <= 0 || seed <= 0) return new List<char>();
        
        List<char> chars = new List<char>();
        for(var i = 'A'; i<='Z'; i++) {
            chars.Add(i);
        }
        for(var i = 'a'; i<='z'; i++) {
            chars.Add(i);
        }
        for(var i = '0'; i<='9'; i++) {
            chars.Add(i);
        }

        int modNum = chars.Count;
        List<char> ret = new List<char>();
        Random randomNum = new Random(seed);
        for (int size = 0; size < listSize; size++){
            // optimise the return random number
            int index = randomNum.Next() % modNum;
            ret.Add(chars[index]);
        }

        return ret;
    }
};