using Microsoft.Win32;
using netDxf;
using Pattern.Core.Parser;
using Pattern.Core.System.DiagridSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DiagridApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<object> CanvasItems { get; set; } = new ObservableCollection<object>();

        private int _ColumnCount =40;
        public int ColumnCount
        {
            get
            {
                return _ColumnCount;
            }
            set
            {
                this._ColumnCount = value;
                RaisePropertyChangedEvent(nameof(ColumnCount));
            }
        }

        private int _RowCount = 20;
        public int RowCount
        {
            get
            {
                return _RowCount;
            }
            set
            {
                this._RowCount = value;
                RaisePropertyChangedEvent(nameof(RowCount));
            }
        }


        private int _ColumnRatio = 5;
        public int ColumnRatio
        {
            get
            {
                return _ColumnRatio;
            }
            set
            {
                this._ColumnRatio = value;
                RaisePropertyChangedEvent(nameof(ColumnRatio));
            }
        }

        private int _RowRatio = 3;
        public int RowRatio
        {
            get
            {
                return _RowRatio;
            }
            set
            {
                this._RowRatio = value;
                RaisePropertyChangedEvent(nameof(RowRatio));
            }
        }


        private int _TriangleMinSize = 2;
        public int TriangleMinSize
        {
            get
            {
                return _TriangleMinSize;
            }
            set
            {
                this._TriangleMinSize = value;
                RaisePropertyChangedEvent(nameof(TriangleMinSize));
            }
        }

        private int _TriangleMaxSize = 5;
        public int TriangleMaxSize
        {
            get
            {
                return _TriangleMaxSize;
            }
            set
            {
                this._TriangleMaxSize = value;
                RaisePropertyChangedEvent(nameof(TriangleMaxSize));
            }
        }


        private string _Magnifications = "9,5,4,3,2";
        public string Magnifications
        {
            get
            {
                return _Magnifications;
            }
            set
            {
                this._Magnifications = value;
                RaisePropertyChangedEvent(nameof(Magnifications));
            }
        }

        private string _Iterations = "2,6,16,40,60";
        public string Iterations
        {
            get
            {
                return _Iterations;
            }
            set
            {
                this._Iterations = value;
                RaisePropertyChangedEvent(nameof(Iterations));
            }
        }


        public ICommand GenerateClick
        {
            get
            {
                return new DelegateCommand(_GenerateClick);
            }
        }

        private bool IsPositiveValidity()
        {
            if (RowCount <= 0)
            {
                MessageBox.Show($"{nameof(RowCount)} must be bigger than 0");
                return false;
            }

            if(ColumnCount <= 0)
            {
                MessageBox.Show($"{nameof(ColumnCount)} must be bigger than 0");
                return false;
            }
            if (RowRatio <= 0)
            {
                MessageBox.Show($"{nameof(RowRatio)} must be bigger than 0");
                return false;
            }

            if (ColumnRatio <= 0)
            {
                MessageBox.Show($"{nameof(ColumnRatio)} must be bigger than 0");
                return false;
            }

            return true;
        }

        private int scale = 10;
        private void _GenerateClick()
        {
            if (!IsPositiveValidity())
            {
                return;
            }
            
            CanvasItems.Clear();
            Canvas canvas = new Canvas();
            RectangleFrameDiagrid grid = new RectangleFrameDiagrid(ColumnCount, RowCount);

            int triMin = TriangleMinSize;
            int triMax = TriangleMaxSize;
            var mags = Magnifications.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            var iters = Iterations.Split(',').Select(n => Convert.ToInt32(n)).ToArray(); ;
            (int, int)[] magIters = mags.Zip(iters, (a, b) => new ValueTuple<int, int>(a, b)).ToArray();

            DiagridPacker dp = new DiagridPacker();
            dp.Pack(ref grid, triMin,triMax, magIters);
            GeometryParser parser = new GeometryParser(ColumnRatio * scale, RowRatio * scale);

            List<List<(int, int)>> units = parser.ToPolygonPointList(grid);
            foreach (List<(int, int)> unit in units)
            {
                List<Point> pts = unit.Select(n => new Point(n.Item1, n.Item2)).ToList();
                pts.Add(pts[0]);
                Polyline polyline = new Polyline()
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,

                    Points = new PointCollection(pts),
                };
                canvas.Children.Add(polyline);
            }
            CanvasItems.Add(canvas);
        }

        public ICommand ExportClick
        {
            get
            {
                return new DelegateCommand(_ExportClick);
            }
        }

        private void SaveDXF(params netDxf.Entities.EntityObject[] entities)
        {
            string fileName;
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Title = "경로를 지정하세요",
                OverwritePrompt = true,
                Filter = "dxf File(*.dxf)|*.dxf",
            };

            if (dialog.ShowDialog() == true)
            {
                fileName = dialog.FileName;

                DxfDocument dxf = new DxfDocument();
                dxf.AddEntity(entities);
                dxf.Save(fileName);      
            }
        }

        private netDxf.Entities.Polyline[] ConvertToDXFGeometry(IEnumerable<Polyline> pls)
        {

            var rs = new List<netDxf.Entities.Polyline>();
            foreach (Polyline pl in pls)
            {
                var vertices = pl.Points.Select(n => new netDxf.Vector3(n.X, n.Y, 0)).ToArray();
                var dxfPl = new netDxf.Entities.Polyline(vertices);

                rs.Add(dxfPl);
            }

            return rs.ToArray();
        }

        private void _ExportClick()
        {
            object maybeCanvas = CanvasItems.SingleOrDefault();

            if (maybeCanvas is Canvas canvas)
            {
                DxfDocument dxf = new DxfDocument();
                List<Polyline> plLIst = new List<Polyline>();
                foreach (object item in canvas.Children)
                {
                    if (item is Polyline pl)
                    {
                        plLIst.Add(pl);
                    }
                }
                var dxfPls = ConvertToDXFGeometry(plLIst);
                SaveDXF(dxfPls);
            }
            else
            {
                MessageBox.Show("No canvas elements.");
            }
        }
    }
}
