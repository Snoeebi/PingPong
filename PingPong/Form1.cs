using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class FrmPingPong : Form
    {
        private const int CHANGEX = 5;
        private const int CHANGEY = 2;

        private int _panelMaxY;
        private int _panelMaxX;
        private Operators _xDirection = Operators.PLUS;
        private Operators _yDirection = Operators.PLUS;

        public FrmPingPong()
        {
            InitializeComponent();

            _panelMaxY = pnlSpiel.Size.Height;
            _panelMaxX = pnlSpiel.Size.Width;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrSpiel.Start();
        }

        private void tmrSpiel_Tick(object sender, EventArgs e)
        {
            Point newBallPoint = GetBallNewBallPointByLocation();

            ovsBall.Location = newBallPoint;
        }

        private Point GetBallNewBallPointByLocation()
        {
            Point newBallPoint;

            if(_yDirection == Operators.PLUS)
            {
                if(_xDirection == Operators.PLUS)
                {
                    newBallPoint = new Point(ovsBall.Location.X + CHANGEX, ovsBall.Location.Y + CHANGEY);
                }
                else
                {
                    newBallPoint = new Point(ovsBall.Location.X - CHANGEX, ovsBall.Location.Y + CHANGEY);
                }
            }
            else
            {
                if(_xDirection == Operators.PLUS)
                {
                    newBallPoint = new Point(ovsBall.Location.X + CHANGEX, ovsBall.Location.Y - CHANGEY);
                }
                else
                {
                    newBallPoint = new Point(ovsBall.Location.X - CHANGEX, ovsBall.Location.Y - CHANGEY);
                }
            }

            if (ovsBall.Location.Y + ovsBall.Height >= _panelMaxY)
            {
                // BALL KOMMT UNTEN AN
                if (_xDirection == Operators.PLUS)
                {
                    newBallPoint = new Point(ovsBall.Location.X + CHANGEX, ovsBall.Location.Y - CHANGEY);
                    _yDirection = Operators.MINUS;
                }
                else
                {
                    newBallPoint = new Point(ovsBall.Location.X - CHANGEX, ovsBall.Location.Y - CHANGEY);
                    _yDirection = Operators.MINUS;
                }
            }
            else if (ovsBall.Location.X + ovsBall.Width >= _panelMaxX)
            {
                // BALL KOMMT RECHTS AN
                if (_yDirection == Operators.PLUS)
                {
                    newBallPoint = new Point(ovsBall.Location.X - CHANGEX, ovsBall.Location.Y + CHANGEY);
                    _xDirection = Operators.MINUS;
                }
                else
                {
                    newBallPoint = new Point(ovsBall.Location.X - CHANGEX, ovsBall.Location.Y - CHANGEY);
                    _xDirection = Operators.MINUS;
                }
            }
            else if (ovsBall.Location.Y <= pnlSpiel.Location.Y)
            {
                // BALL KOMMT OBEN AN
                if (_xDirection == Operators.PLUS)
                {
                    newBallPoint = new Point(ovsBall.Location.X + CHANGEX, ovsBall.Location.Y + CHANGEY);
                    _yDirection = Operators.PLUS;
                }
                else
                {
                    newBallPoint = new Point(ovsBall.Location.X - CHANGEX, ovsBall.Location.Y + CHANGEY);
                    _yDirection = Operators.PLUS;
                }
            }
            else if (ovsBall.Location.X <= pnlSpiel.Location.X)
            {
                // BALL KOMMT LINKS AN
                if (_yDirection == Operators.PLUS)
                {
                    newBallPoint = new Point(ovsBall.Location.X + CHANGEX, ovsBall.Location.Y + CHANGEY);
                    _xDirection = Operators.PLUS;
                }
                else
                {
                    newBallPoint = new Point(ovsBall.Location.X + CHANGEX, ovsBall.Location.Y - CHANGEY);
                    _xDirection = Operators.PLUS;
                }
            }

            return newBallPoint;
        }
    }
}
