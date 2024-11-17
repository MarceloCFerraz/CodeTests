# Maximize NxN left-quadrant matrix

Sean invented a game involving a matrix where each cell of the matrix contains an integer. He can reverse any of its rows or columns any number of times. The goal of the game is to maximize the sum of the elements in the submatrix located in the upper-left quadrant of the matrix.
Given the initial configurations for matrices, help Sean reverse the rows and columns of each matrix in the best possible way so that the sum of the elements in the matrix's upper-left quadrant is maximal.

Example:
matrix = [[1, 2], [3, 4]]

1 2
3 4

It is 2 x 2 and we want to maximize the top left quadrant, a 1 x 1 matrix. Reverse row 1:

1 2
4 3

And now reverse column 0:

4 2
1 3

The maximal sum is 4.

Function Description
Complete the flippingMatrix function in the editor below. flippingMatrix has the following parameters:

- int matrix[2n][2n]: a 2-dimensional array of integers

Returns

- int: the maximum sum possible (sum of all elements in the upper-left corner of the final n x n matrix).
