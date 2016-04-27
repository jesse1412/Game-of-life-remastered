﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_life_remastered
{

    class QuadTreeNode
    {

        //For leaves.
        int storedX;
        int storedY;

        //For Branch.
        int sectorWidth;
        int sectorHeight;
        QuadTreeNode[] childNodes = new QuadTreeNode[4];
        QuadTreeNode parent;

        //For both.
        nodeType thisNodeType = nodeType.leaf;

        public QuadTreeNode(int x, int y, int height, int width, QuadTreeNode constructorParent)
        {

            storedX = x;
            storedY = y;
            sectorWidth = width;
            sectorHeight = height;
            parent = constructorParent;

        }

        /// <summary>
        /// Adds a given pixel to the quad tree.
        /// </summary>
        /// <param name="x">X co-ordinate of the pixel.</param>
        /// <param name="y">Y co-ordinate of the pixel.</param>
        public void addPixel(int x, int y, int localX = 0, int localY = 0)
        {

            if (localX + localY == 0)
            {

                localX = x;
                localY = y;

            }

            if (parent == null)
            {

                if (storedX == 0 && storedY == 0)
                {

                    storedX = x;
                    storedY = y;
                    return;

                }

            }

            quadrants workingQuadrant = getQuadrant(localX, localY);
            int workingChild = 0;

            switch (workingQuadrant)
            {

                case quadrants.topLeft:
                    workingChild = 0;
                    break;

                case quadrants.topRight:
                    workingChild = 1;
                    localX -= sectorWidth / 2;
                    break;

                case quadrants.bottomLeft:
                    workingChild = 2;
                    localY -= sectorHeight / 2;
                    break;

                case quadrants.bottomRight:
                    workingChild = 3;
                    localY -= sectorHeight / 2;
                    localX -= sectorWidth / 2;
                    break;

            }

            if (thisNodeType == nodeType.leaf) //This block moves a value stored by the current leaf into a lower leaf. This is done as the current node is a leaf and must expand into a stem.
            {

                thisNodeType = nodeType.stem;
                childNodes[workingChild] = new QuadTreeNode(x, y, sectorHeight / 2, sectorWidth / 2, this);
                this.addPixel(storedX, storedY, localX, localY);
                return;

            }

            else if (childNodes[workingChild] == null) //if the target quadrant has no instance.
            {

                childNodes[workingChild] = new QuadTreeNode(x, y, sectorHeight / 2, sectorWidth / 2, this); //Create an instance and store the target co-ordinate in it.
                return;

            }

            else
            {

                childNodes[workingChild].addPixel(x, y, localX, localY);

            }

        }

        /// <summary>
        /// Checks if the given pixel is alive.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="localX">Used for recursive calls to get the x position local to the current sector.</param>
        /// <param name="localY">Used for recursive calls to get the x position local to the current sector.</param>
        /// <returns></returns>
        public bool isPexelAlive(int x, int y, int localX = 0, int localY = 0)
        {

            if (storedX == x && storedY == y && thisNodeType == nodeType.leaf)
            {

                return true;

            }

            if (parent == null)
            {

                localX = x;
                localY = y;

            }

            quadrants workingQuadrant = getQuadrant(localX, localY);
            int workingChild = 0;

            switch (workingQuadrant)
            {

                case quadrants.topLeft:
                    workingChild = 0;
                    break;

                case quadrants.topRight:
                    workingChild = 1;
                    localX -= sectorWidth / 2;
                    break;

                case quadrants.bottomLeft:
                    workingChild = 2;
                    localY -= sectorHeight / 2;
                    break;

                case quadrants.bottomRight:
                    workingChild = 3;
                    localY -= sectorHeight / 2;
                    localX -= sectorWidth / 2;
                    break;

            }

            if (childNodes[workingChild] != null)
            {

                return childNodes[workingChild].isPexelAlive(x, y, localX, localY);

            }

            else
            {

                return false;

            }

        }

        /// <summary>
        /// Removes a given pixel from the quad tree.
        /// </summary>
        /// <param name="x">X co-ordinate of the pixel.</param>
        /// <param name="y">Y co-ordinate of the pixel.</param>
        public void removePixel(int x, int y)
        {



        }

        /// <summary>
        /// Returns the quadrant that the given co-ordinates lies in based on the stored sector dimensions.
        /// </summary>
        /// <param name="xPosition"></param>
        /// <param name="yPosition"></param>
        /// <returns></returns>
        private quadrants getQuadrant(int xPosition, int yPosition)
        {

            if (xPosition <= sectorWidth / 2 && yPosition <= sectorHeight / 2)
            {

                return quadrants.topLeft;

            }

            else if (xPosition > sectorWidth / 2 && yPosition <= sectorHeight / 2)
            {

                return quadrants.topRight;

            }

            else if (xPosition <= sectorWidth / 2 && yPosition > sectorHeight / 2)
            {

                return quadrants.bottomLeft;

            }

            else//if (xPosition > sectorWidth / 2 && yPosition > sectorHeight / 2)
            {

                return quadrants.bottomRight;

            }

        }

        public enum quadrants
        {

            topLeft,
            topRight,
            bottomLeft,
            bottomRight

        }
        public enum nodeType
        {

            stem,
            leaf

        }

    }

}
