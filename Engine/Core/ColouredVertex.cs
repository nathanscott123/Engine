﻿using OpenTK;
using OpenTK.Graphics;

namespace Engine.Core
{
    struct ColouredVertex
    {
        public const int Size = (3 + 4) * 4; // size of struct in bytes

        private readonly Vector3 position;
        private readonly Color4 color;

        public ColouredVertex(Vector3 position, Color4 color)
        {
            this.position = position;
            this.color = color;
        }
    }
}
