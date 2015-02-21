using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;

namespace Testing1
{
    class MapRow
    {
        public List<MapCell> Columns = new List<MapCell>();
    }

    class TileMap
    {
        public List<MapRow> Rows = new List<MapRow>();
        public int MapWidth = 100;
        public int MapHeight = 100;

        public TileMap(String filename)
        {
            StreamReader reader = new StreamReader(TitleContainer.OpenStream(filename));
            int width = 0, height = 0;
            List<string> linesFromFile = new List<string>();

            string line = reader.ReadLine();
            width = line.Length;

            while (line != null)
            {
                height++;
                linesFromFile.Add(line);
                line = reader.ReadLine();
            }
            for (int y = 0; y < MapHeight; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < MapWidth; x++)
                {
                    thisRow.Columns.Add(new MapCell(0));
                }
                Rows.Add(thisRow);
            }
            char[,] tiles = new char[width, height];

            for (int j = 0; j < height; j++)
            {
                string l = linesFromFile[j];
                for (int i = 0; i < width; i++)
                {
                    char c = l[i];
                    switch (c)
                    {
                        case 'g': Rows[j].Columns[i].TileID = 0; break;
                        case 'd': Rows[j].Columns[i].TileID = 1; break;
                        case 'w': Rows[j].Columns[i].TileID = 2; break;
                        case 'a': Rows[j].Columns[i].TileID = 3; break;
                        case 't': Rows[j].Columns[i].TileID = 0; Rows[j].Columns[i].AddBaseTile(98); break;
                        case 'b': Rows[j].Columns[i].TileID = 5; break;
                        case 'r': Rows[j].Columns[i].TileID = 7; break;
                        default: Rows[j].Columns[i].TileID = 0; break;
                    }

                }
            }

            // Create Sample Map Data
            //Rows[0].Columns[3].TileID = 3;
            //Rows[0].Columns[4].TileID = 3;
            //Rows[0].Columns[5].TileID = 1;
            //Rows[0].Columns[6].TileID = 1;
            //Rows[0].Columns[7].TileID = 1;

            //Rows[1].Columns[3].TileID = 3;
            //Rows[1].Columns[4].TileID = 1;
            //Rows[1].Columns[5].TileID = 1;
            //Rows[1].Columns[6].TileID = 1;
            //Rows[1].Columns[7].TileID = 1;

            //Rows[2].Columns[2].TileID = 3;
            //Rows[2].Columns[3].TileID = 1;
            //Rows[2].Columns[4].TileID = 1;
            //Rows[2].Columns[5].TileID = 1;
            //Rows[2].Columns[6].TileID = 1;
            //Rows[2].Columns[7].TileID = 1;

            //Rows[3].Columns[2].TileID = 3;
            //Rows[3].Columns[3].TileID = 1;
            //Rows[3].Columns[4].TileID = 1;
            //Rows[3].Columns[5].TileID = 2;
            //Rows[3].Columns[6].TileID = 2;
            //Rows[3].Columns[7].TileID = 2;

            //Rows[4].Columns[2].TileID = 3;
            //Rows[4].Columns[3].TileID = 1;
            //Rows[4].Columns[4].TileID = 1;
            //Rows[4].Columns[5].TileID = 2;
            //Rows[4].Columns[6].TileID = 2;
            //Rows[4].Columns[7].TileID = 2;

            //Rows[5].Columns[2].TileID = 3;
            //Rows[5].Columns[3].TileID = 1;
            //Rows[5].Columns[4].TileID = 1;
            //Rows[5].Columns[5].TileID = 2;
            //Rows[5].Columns[6].TileID = 2;
            //Rows[5].Columns[7].TileID = 2;

            //Rows[3].Columns[5].AddBaseTile(30);
            //Rows[4].Columns[5].AddBaseTile(27);
            //Rows[5].Columns[5].AddBaseTile(28);

            //Rows[3].Columns[6].AddBaseTile(25);
            //Rows[5].Columns[6].AddBaseTile(24);

            //Rows[3].Columns[7].AddBaseTile(31);
            //Rows[4].Columns[7].AddBaseTile(26);
            //Rows[5].Columns[7].AddBaseTile(29);

            //Rows[4].Columns[6].AddBaseTile(104);
            // End Create Sample Map Data
        }
    }
}
