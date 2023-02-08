using System.Collections.Generic;

public class NodeConnector
{
    public void ConnectNodes(List<Node> unconnectedNodes, int rows, int columns)
    {
        Node[,] nodes = new Node[rows, columns];
        int nodeIndex = 0;
        
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++, nodeIndex++)
            {
                nodes[row, column] = unconnectedNodes[nodeIndex];
            }
        }

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                if ((row == 0 && column == 0) || (row == rows-1 && column == columns-1))
                {
                    int offset = row == 0 ? 1 : -1;
                    nodes[row, column].AddEdge(nodes[row + offset, column]); 
                    nodes[row, column].AddEdge(nodes[row, column + offset]);
                    continue;
                }

                if ((row == 0 && column == columns - 1) || (row == rows - 1 && column == 0))
                {
                    int offset = row == 0 ? 1 : -1;
                    nodes[row, column].AddEdge(nodes[row + offset, column]); 
                    nodes[row, column].AddEdge(nodes[row, column - offset]);
                    continue;
                }

                if (column == 0 || column == columns - 1)
                {
                    int columnOffset = column == 0 ? 1 : -1;

                    nodes[row, column].AddEdge(nodes[row, column + columnOffset]); 
                    nodes[row, column].AddEdge(nodes[row - 1, column]);
                    nodes[row, column].AddEdge(nodes[row + 1, column]);
                    continue;
                }

                if (row == 0 || row == rows - 1)
                {
                    int rowOffset = row == 0 ? 1 : -1;

                    nodes[row, column].AddEdge(nodes[row + rowOffset, column]); 
                    nodes[row, column].AddEdge(nodes[row, column - 1]);
                    nodes[row, column].AddEdge(nodes[row, column + 1]);//
                    continue;
                }

                nodes[row, column].AddEdge(nodes[row - 1, column]);
                nodes[row, column].AddEdge(nodes[row + 1, column]);
                nodes[row, column].AddEdge(nodes[row, column - 1]);                             
                nodes[row, column].AddEdge(nodes[row, column + 1]);                             
            }
        }
    }
}