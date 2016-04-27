using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_life_remastered
{

    class Root
    {

        int drawHeight; //Height of the draw field.
        int drawWidth; //Width of the draw field.

        QuadTreeNode Node; //Starter node for the quad tree.

        public Root(int xHeightConstructor, int yHeightConstructor)
        {

            drawHeight = xHeightConstructor;
            drawWidth = xHeightConstructor;
            Node = new QuadTreeNode(0, 0, drawHeight, drawWidth, null);

        }

        /// <summary>
        /// Adds a given pixel to the quad tree.
        /// </summary>
        /// <param name="x">X co-ordinate of the pixel.</param>
        /// <param name="y">Y co-ordinate of the pixel.</param>
        public void addPixel(int x, int y)
        {

            Node.addPixel(x, y);

        }

        /// <summary>
        /// Removes a given pixel from the quad tree.
        /// </summary>
        /// <param name="x">X co-ordinate of the pixel.</param>
        /// <param name="y">Y co-ordinate of the pixel.</param>
        public void removePixel(int x, int y)
        {

            Node.removePixel(x, y);

        }

        public bool isPixelAlive(int x, int y)
        {

            return Node.isPexelAlive(x, y);

        }

    }

}
