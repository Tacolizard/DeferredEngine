﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeferredEngine.Recources.Helper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DeferredEngine.Entities
{
    public class VolumeTextureEntity : TransformableObject
    {
        public sealed override Vector3 Position { get; set; }
        public override Vector3 Scale { get; set; }
        public sealed override int Id { get; set; }
        public override Matrix RotationMatrix { get; set; }
        public override bool IsEnabled { get; set; }
        public override TransformableObject Clone { get; }
        public sealed override string Name { get; set; }

        public Vector3 Size;

        public float SizeX
        {
            get { return _sizeX; }
            set { _sizeX = value;
                Size.X = value;
            }
        }
        public float SizeY
        {
            get { return _sizeY; }
            set
            {
                _sizeY = value;
                Size.Y = value;
            }
        }
        public float SizeZ
        {
            get { return _sizeZ; }
            set
            {
                _sizeZ = value;
                Size.Z = value;
            }
        }

        public Vector3 Resolution = 2 * Vector3.One;

        public Texture2D Texture;
        public bool NeedsUpdate = false;
        private float _sizeX;
        private float _sizeY;
        private float _sizeZ;

        public VolumeTextureEntity(string texturepath, GraphicsDevice graphics, Vector3 position, Vector3 size)
        {
            Position = position;

            Id = IdGenerator.GetNewId();
            Name = GetType().Name + " " + Id;
            int zdepth;
            Texture = DataStream.LoadFromFile(graphics, texturepath, out zdepth);
            Resolution.Y = Texture.Height;
            Resolution.Z = zdepth;
            Resolution.X = Texture.Width / zdepth;

            Size = size;
            _sizeX = size.X;
            _sizeY = size.Y;
            _sizeZ = size.Z;

        }
    }
}
