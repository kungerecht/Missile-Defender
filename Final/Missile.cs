//Kevin Ungerecht
//Missile Command for FINAL

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Final
{
    class Missile
    {
        private PointF initial;
        private PointF s;
        private PointF e;
        private int ticks;
        private float slope;
        private float b;
        private bool exploded = false;

        public Missile(PointF begin, PointF end) {
            this.s = begin;
            this.initial = begin;
            this.initial.Y = this.initial.Y - 1;
            this.e = end;
            this.ticks = 0;
            this.slope = (end.Y - begin.Y) / (end.X - begin.X);
            this.b = (begin.Y - (slope * begin.X));
        }

        public PointF getStart() {
            return this.s;
        }

        public PointF getEnd()
        {
            return this.e;
        }

        public void setEnd(PointF newE)
        {
            this.e = newE;
        }

        public void setStart(PointF newS)
        {
            this.s = newS;
        }

        public PointF getInitial() {
            return this.initial;
        }

        public int getTicks() {
            return this.ticks;
        }

        public void setTicks(int i) {
            this.ticks = i;
        }

        public float getSlope() {
            return this.slope;
        }

        public float getB() {
            return this.b;
        }

        public bool isExploded() {
            return this.exploded;
        }

        public void setExploded(bool exp) {
            this.exploded = exp;
        }
    }
}
