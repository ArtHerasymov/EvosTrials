using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence.Library
{
    public class SequenceLibrary
    {
        private SequenceLibrary() { }

        /// <summary>Returns a chunk of the sequence by the given upper and lower indices.
        /// <param name="lower">Used to establish lower index of the calculated sequence.</param>
        /// <param name="upper">Used to establish upper index of the calculated sequence.</param>
        public static int[] GetPart(int lower, int upper)
        {
            if (lower < 1 || upper < 2 || lower > upper) throw new ArgumentException();

            int[] resultingSequence = new int[upper - lower + 1];

            for (int i = 0; i <= upper - lower; i++)
            {
                if (i > 2)
                    resultingSequence[i] = checked(resultingSequence[i - 1] + resultingSequence[i - 2] + resultingSequence[i - 3]);
                else
                    resultingSequence[i] = checked(CalculateNthTerm(lower + i));
            }
            return resultingSequence;
        }

        /// <summary>Performs a basic multiplication of two matrices.
        /// Using nested loops as the complexity is irrelevant for 3x3 matrices
        /// <param name="leftOperand">Used to specify the first matrix for multiplication.</param>
        /// <param name="rightOperand">Used to specify the second matrix for multiplication.</param>
        private static void MultiplyMatrices(int[,] leftOperand, int[,] rightOperand)
        {
            int[,] resultingMatrix = new int[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    resultingMatrix[i, j] = 0;
                    for (int k = 0; k < 3; k++)
                        resultingMatrix[i, j] += leftOperand[i, k] * rightOperand[k, j];
                }
            }

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    leftOperand[i, j] = resultingMatrix[i, j];
        }

        /// <summary>Performs enhanced exponentiation of the matrix.
        /// <param name="matrixForExponentiation">Used to specify the matrix for exponentiation.</param>
        /// <param name="power">Used to specify the power for exponentiation</param>
        private static int Power(int[,] matrixForExponentiation, int power)
        {

            int[,] operatorMatrix = { { 1, 1, 1 }, { 1, 0, 0 },
                                   { 0, 1, 0 } };

            if (power == 1)
                return matrixForExponentiation[0, 0] + matrixForExponentiation[0, 1] + matrixForExponentiation[0, 2];

            Power(matrixForExponentiation, power / 2);

            MultiplyMatrices(matrixForExponentiation, matrixForExponentiation);

            if (power % 2 != 0)
                MultiplyMatrices(matrixForExponentiation, operatorMatrix);

            return matrixForExponentiation[0, 0] + matrixForExponentiation[0, 1] + matrixForExponentiation[0, 2];
        }

        /// <summary>Calculates a single term from the sequence.
        /// <param name="n">Used to specify the index of the term for extraction from the sequence.</param>
        private static int CalculateNthTerm(int n)
        {
            if (n < 4) return 1;
            int[,] operatorMatrix = { { 1, 1, 1 }, { 1, 0, 0 },
                                 { 0, 1, 0 } };

            return Power(operatorMatrix, n - 3);
        }
    }
}
