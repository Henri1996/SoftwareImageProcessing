using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ProjetInfo
{
	public class Pixel
	{
		// les attributs  
		private byte R;
		private byte G;
		private byte B;

		#region Les propriétés
		public byte R1
		{
			get
			{
				return R;
			}

			set
			{
				R = value;
			}
		}

		public byte G1
		{
			get
			{
				return G;
			}

			set
			{
				G = value;
			}
		}

		public byte B1
		{
			get
			{
				return B;
			}

			set
			{
				B = value;
			}
		}
		#endregion




		// Construeucteur
		public Pixel(byte Red, byte Green, byte Blue)
		{

			R1 = Red;
			G1 = Green;
			B1 = Blue;

		}

		public void Afficher()
		{
			Console.Write(R1 + " " + G1 + " " + B1 + "\t");


		}

		public void Afficher1()
		{
			//Console.Write(Math.Round(((R1 +G1 + B1)/3)/255,1) + " ");
			decimal nb = ((R1 + G1 + B1) / 3) / 255m;
			nb = Math.Round(nb, 1);
			Console.Write(nb + " ");
		}
	}
}
	

