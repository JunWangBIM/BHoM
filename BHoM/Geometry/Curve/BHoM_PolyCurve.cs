﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHoM.Geometry
{
    public class PolyCurve : Curve
    {
        private List<Curve> m_Curves;

        internal PolyCurve() { }
        internal PolyCurve(Curve c1, Curve c2)
        {
            m_Curves = new List<Curve>() { c1, c2 };
            m_Dimensions = 3;

            // TODO - have a better look at this. For now, jsut there to fix Eddy's stuff
            m_ControlPoints = c1.ControlPointVector.Concat(c2.ControlPointVector).ToArray();
        }

        public override void CreateNurbForm()
        {
            m_Knots = new double[m_Curves.Count];

            double accum = 0;
            for (int i = 1; i < m_Curves.Count; i++)
            {
                accum += m_Curves[i].Domain[1];
                m_Knots[i] = accum;
            }
            IsNurbForm = true;
        }

        public override Point StartPoint
        {
            get
            {
                return m_Curves.Count > 0 ? m_Curves[0].StartPoint : null;
            }
        }

        public override Point EndPoint
        {
            get
            {
                return m_Curves.Count > 0 ? m_Curves[m_Curves.Count - 1].EndPoint : null;
            }
        }

        public override Point PointAt(double t)
        {
            int i = 0;
            while (t > m_Knots[i] && i < m_Knots.Length) i++;

            return m_Curves[i].PointAt(t - m_Knots[i]);
        }

        public override Vector TangentAt(double t)
        {
            int i = 0;
            while (t > m_Knots[i] && i < m_Knots.Length) i++;

            return m_Curves[i].TangentAt(t - m_Knots[i]);
        }

        public override BoundingBox Bounds()
        {
            Point max = m_Curves[0].Max;
            Point min = m_Curves[0].Min;
            for (int i = 1; i < m_Curves.Count; i++)
            {
                max = Point.Max(max, m_Curves[i].Max);
                min = Point.Min(min, m_Curves[i].Min);
            }
            return new BoundingBox(min, max);
        }

        public override List<Curve> Explode()
        {
            List<Curve> exploded = new List<Curve>();
            for (int i = 0; i < m_Curves.Count; i++)
            {
                exploded.AddRange(m_Curves[i].Explode());
            }
            return exploded;
        }

        public override Curve DuplicateCurve()
        {
            PolyCurve c = base.DuplicateCurve() as PolyCurve;
            c.m_Curves = new List<Curve>();
            for (int i = 0; i < m_Curves.Count; i++)
            {
                c.m_Curves.Add(m_Curves[i].DuplicateCurve());
            }
            return c;
        }

        /*internal override double[] ControlPoint(int i)   // AD - Commented to make it work with control points now defined in PolyCurve
        {
            int currentIndex = i;

            for (int j = 0; j < m_Curves.Count; j++)
            {
                if (currentIndex < m_Curves[j].PointCount)
                {
                    return m_Curves[j].ControlPoint(currentIndex);
                }
                currentIndex = currentIndex -m_Curves[j].PointCount + 1;
            }
            return null;
        }*/

        /*public override int PointCount                // AD - Commented to make it work with control points now defined in PolyCurve
        {
            get
            {
                int count = 0;
                for (int i = 0; i < m_Curves.Count; i++)
                {
                    count += m_Curves[i].PointCount - 1;
                }
                return count;
            }
        }*/

        public override bool IsPlanar()
        {
            double[] controlPoint = new double[PointCount * ( m_Dimensions)];
            for (int i = 0; i < controlPoint.Length; i += m_Dimensions)
            {
                double[] p = ControlPoint(i / m_Dimensions);
                controlPoint[i] = p[0];
                controlPoint[i + 1] = p[1];
                controlPoint[i + 2] = p[2];
            }
            return Plane.PointsInSamePlane(controlPoint, m_Dimensions);
        }


        public override void Transform(Transform t)
        {
            for (int i = 0; i < m_Curves.Count; i++)
            {
                m_Curves[i].Transform(t);
            }
        }

        public override void Translate(Vector v)
        {
            for (int i = 0; i < m_Curves.Count; i++)
            {
                m_Curves[i].Translate(v);
            }
        }

        public override void Mirror(Plane p)
        {
            for (int i = 0; i < m_Curves.Count; i++)
            {
                m_Curves[i].Mirror(p);
            }
        }

        public override void Project(Plane p)
        {
            for (int i = 0; i < m_Curves.Count; i++)
            {
                m_Curves[i].Project(p);
            }
        }

        public override void Update()
        {
            for (int i = 0; i < m_Curves.Count; i++)
            {
                m_Curves[i].Update();
            }
        }

        public override Curve Flip()
        {
            for (int i = 0; i < m_Curves.Count; i++)
            {
                m_Curves[i].Flip();
            }
            m_Curves.Reverse();
            return this;
        }

        public override Point ClosestPoint(Point point)
        {
            List<Point> points = ControlPoints;

            double minDist = 1e10;
            Point closest = StartPoint;

            for (int i = 0; i < m_Curves.Count; i++)
            {
                Point cp = m_Curves[i].ClosestPoint(point);
                double dist = cp.DistanceTo(point);
                if (dist < minDist)
                {
                    closest = cp;
                    minDist = dist;
                }
            }

            return closest;
        }

    }
}