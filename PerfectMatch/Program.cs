using System;

namespace PerfectMatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var values1 = new[] { 1, 2, 3, 4 };

            var applicants = new int[4][];
            applicants[0] = new int[4] { 4, 3, 1, 2 };
            applicants[1] = new int[4] { 2, 1, 3, 4 };
            applicants[2] = new int[4] { 1, 3, 4, 2 };
            applicants[3] = new int[4] { 4, 3, 1, 2 };

            var apartments = new int[4][];
            apartments[0] = new int[4] { 3, 2, 4, 1 };
            apartments[1] = new int[4] { 2, 3, 1, 4 };
            apartments[2] = new int[4] { 3, 1, 2, 4 };
            apartments[3] = new int[4] { 3, 2, 4, 1 };

            //var values1 = new[] { 1, 2, 3, 4, 5, 6, 7 };

            //var applicants = new int[7][];
            //applicants[0] = new int[7] { 3, 4, 2, 1, 6, 7, 5 };
            //applicants[1] = new int[7] { 6, 4, 2, 3, 5, 1, 7 };
            //applicants[2] = new int[7] { 6, 3, 5, 7, 2, 4, 1 };
            //applicants[3] = new int[7] { 1, 6, 3, 2, 4, 7, 5 };
            //applicants[4] = new int[7] { 1, 6, 5, 3, 4, 7, 2 };
            //applicants[5] = new int[7] { 1, 7, 3, 4, 5, 6, 2 };
            //applicants[6] = new int[7] { 5, 6, 2, 4, 3, 7, 1 };

            //var apartments = new int[7][];
            //apartments[0] = new int[7] { 4, 5, 3, 7, 2, 6, 1 };
            //apartments[1] = new int[7] { 5, 6, 4, 7, 3, 2, 1 };
            //apartments[2] = new int[7] { 1, 6, 5, 4, 3, 7, 2 };
            //apartments[3] = new int[7] { 3, 5, 6, 7, 2, 4, 1 };
            //apartments[4] = new int[7] { 1, 7, 6, 4, 3, 5, 2 };
            //apartments[5] = new int[7] { 6, 3, 7, 5, 2, 4, 1 };
            //apartments[6] = new int[7] { 1, 7, 4, 2, 6, 5, 3 };


            int maximum = 0;
            int[] match = null;
            foreach (var permutation in values1.GetPermutations())  // We definitely need to implement validation here, to check if there are any duplicate apartman / applicant within rates. Also the number of applicants needs to be the same as the number of apartments.
            {
                var combination = permutation as int[];
                var sum = 0;
                for(var index = 0; index < values1.Length; index++)
                {
                    var position1 = values1.Length - Array.IndexOf(applicants[index], combination[index]);
                    var position2 = values1.Length - Array.IndexOf(apartments[index], combination[index]);
                    sum += position1 * position2;
                }
                if (sum > maximum)
                {
                    maximum = sum;
                    match = combination;
                }
            }

            Console.WriteLine(string.Join(',', match));
            //Console.ReadLine();

            // Question: Does the solution run in reasonable time? How fast and why?
            // Answer: This solution runs in reasonable time for small number of applicants/apartments, but when the number of applicants/apartments grow, iteration grows by factorial (n!)

            // Question: How would you deploy this application to production? Explain the design.
            // Answer: First i would do a pull request on a branch where the dev environment is. Then from develop branch I would do build for dev environment, 
            //         after test on dev environment, I would do cherry - picking on separate RC branch from which I would build QA or Staging environment (depends on needs).
            //         After final testing, from same RC branch I would deploy application on production, which is secured through release management and best practices.

            //Question: Which design pattern could we apply in our design if we would need to extend our algorithm?
            //              - What do we need to adapt in our code to implement it ?
            //Answer: We could use strategy pattern which enables an algorithm to be encapsulated within a class and switched at runtime
            //        We definitely need to implement validation and allow user to input matrix with various numbers of applicatnts / apartments
        }
    }
}
