using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GameGrid
    {
        readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public GameGrid(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            grid = new int[rows, columns];
        }

        public bool IsInside(int r, int c)
        {
            return 0 <= r && r < Rows && 0 <= c && c < Columns;
        }

        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }

        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
                if (grid[r, c] == 0) return false;
            return true;
        }

        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
                if (grid[r, c] != 0) return false;
            return true;
        }

        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
                grid[r, c] = 0;
        }

        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }

        public int ClearFullRows()
        {
            int cleared = 0;

            for (int r = Rows-1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }
            return cleared;
        }

    }




    /*
     * lớp (class) tên là GameGrid. Lớp này có hai thuộc tính là Rows và Columns để đại diện cho số hàng và số cột 
     * của lưới trong trò chơi.

Ngoài ra, lớp GameGrid còn có một mảng hai chiều (two-dimensional array) là grid để lưu trữ dữ liệu 
    của lưới trong trò chơi. Biến grid được khai báo là readonly để chỉ có thể được khởi tạo 
    giá trị một lần và không thể thay đổi giá trị của nó sau khi đã được khởi tạo.

Trong lớp GameGrid, có định nghĩa một phương thức (method) là this[int r, int c] dùng để lấy hoặc đặt giá trị cho một ô của lưới. 
    Phương thức này sử dụng cú pháp indexers của C#, cho phép truy cập vào các phần tử của mảng grid 
    bằng cách sử dụng dấu ngoặc vuông [].

Khi sử dụng phương thức này, ta có thể ghi nhận giá trị tại vị trí (r, c) của lưới bằng cách
    sử dụng toán tử get như sau: int value = gameGrid[r, c]; và cũng có thể thiết lập giá trị 
    cho vị trí này bằng cách sử dụng toán tử set như sau: gameGrid[r, c] = value;.

Tóm lại, lớp GameGrid được sử dụng để lưu trữ và truy cập dữ liệu của lưới trong trò chơi, 
    cung cấp các thuộc tính để đại diện cho kích thước của lưới và sử dụng phương thức indexers
    để truy cập và thiết lập giá trị của từng ô trong lưới.
     */
}
