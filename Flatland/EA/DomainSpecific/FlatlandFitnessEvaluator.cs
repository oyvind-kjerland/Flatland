using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flatland.EA.DomainSpecific
{
    class FlatlandFitnessEvaluator : FitnessEvaluator
    {
        private double foodWeight = 1;
        private double poisonWeight = -1;
        public ANN ann;
        public bool changeBoardBetweenGenerations;
        public List<Board> boards;
        private float[] FPD;
        private int[] dimensions;
        public int timeSteps;

        public void CreateBoard()
        {
            boards.Add(new Board(FPD, dimensions));
        }

        public override float Evaluate(Individual individual)
        {
            int foodScore = 0;
            int poisonScore = 0;

            foreach (Board b in boards)
            {
                b.ResetBoard();

                ANNWeightPhenotype phenotype = (ANNWeightPhenotype)individual.Phenotype;
                ann.SetWeights(phenotype.Weights);

                for (int i = 0; i < timeSteps; i++)
                {
                    b.player.Move(b.player.GetMove());
                }

                foodScore += b.player.foodScore;
                poisonScore += b.player.poisonScore;
            }

            return (float)(foodScore * foodWeight + poisonScore * poisonWeight);
        }

        public override void NextGeneration()
        {
            if (changeBoardBetweenGenerations)
            {
                int numBoards = boards.Count;
                boards.Clear();

                for (int i = 0; i < numBoards; i++)
                {
                    Board board = new Board(FPD, dimensions);
                    board.player.ann = this.ann;
                    boards.Add(board);
                }
            }
        }
    }
}
