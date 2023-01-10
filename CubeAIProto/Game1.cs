using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Threading;

namespace CubeAIProto
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Sprite[,] ff = new Sprite[3, 3];
        private Sprite[,] rf = new Sprite[3, 3];
        private Sprite[,] lf = new Sprite[3, 3];
        private Sprite[,] uf = new Sprite[3, 3];
        private Sprite[,] df = new Sprite[3, 3];
        private Sprite[,] bf = new Sprite[3, 3];
        private CubeM cube = new CubeM();
        private Texture2D tex;
        private TimerManager tmanager = new TimerManager(500);

        private int[] edgealgo = new int[15]
        {
             4,5,1,2,1,6,1,1,2,1,2,4,5,1,3
        };
        List<int> unsolved = new List<int>()
        {
            0,2,3,4,5,6,7,8,9,10,11,13,14,15,16,17,18,19,20,21,22,23
        };
        private Color[] bfind = new Color[2];
        private Color[] a = new Color[2]
        {
            Color.White,Color.Blue
        };
        private Color[] b = new Color[2]
        {
            Color.White,Color.Red
        };
        private Color[] c = new Color[2]
        {
            Color.White,Color.Green
        };
        private Color[] d = new Color[2]
        {
            Color.White,Color.Orange
        };//
        private Color[] e = new Color[2]
        {
            Color.Orange,Color.White
        };
        private Color[] f = new Color[2]
        {
            Color.Orange,Color.Green
        };
        private Color[] g = new Color[2]
        {
            Color.Orange,Color.Yellow
        };
        private Color[] h = new Color[2]
        {
            Color.Orange,Color.Blue
        };//
        private Color[] i = new Color[2]
        {
            Color.Green,Color.White
        };
        private Color[] j = new Color[2]
        {
            Color.Green,Color.Red
        };
        private Color[] k = new Color[2]
        {
            Color.Green,Color.Yellow
        };
        private Color[] l = new Color[2]
        {
            Color.Green,Color.Orange
        };
        private Color[] m = new Color[2]
        {
            Color.Red,Color.White
        };
        private Color[] n = new Color[2]
        {
            Color.Red,Color.Blue
        };
        private Color[] o = new Color[2]
        {
            Color.Red,Color.Yellow
        };
        private Color[] p = new Color[2]
        {
            Color.Red,Color.Green
        };
        private Color[] q = new Color[2]
        {
            Color.Blue,Color.White
        };
        private Color[] r = new Color[2]
        {
            Color.Blue,Color.Orange
        };
        private Color[] s = new Color[2]
        {
            Color.Blue,Color.Yellow
        };
        private Color[] t = new Color[2]
        {//
            Color.Blue,Color.Red
        };
        private Color[] u = new Color[2]
        {
            Color.Yellow,Color.Green
        };
        private Color[] v = new Color[2]
        {
            Color.Yellow,Color.Red
        };
        private Color[] w = new Color[2]
        {
            Color.Yellow,Color.Blue
        };
        private Color[] x = new Color[2]
        {
            Color.Yellow,Color.Orange
        };

        private int timer;
        private Color[][] wholecubenew =
        {
            new Color[] {Color.White,Color.Blue },
            new Color[]{Color.White,Color.Red },
            new Color[]{Color.White,Color.Green },
            new Color[]{Color.White,Color.Orange },
            new Color[]{Color.Orange,Color.White },
            new Color[]{Color.Orange,Color.Green },
            new Color[]{Color.Orange,Color.Yellow },
            new Color[]{Color.Orange,Color.Blue },
            new Color[]{Color.Green,Color.White },
            new Color[]{Color.Green,Color.Red },
            new Color[]{Color.Green,Color.Yellow },
            new Color[]{Color.Green,Color.Orange },
            new Color[]{ Color.Red,Color.White},
            new Color[]{Color.Red,Color.Blue },
            new Color[]{Color.Red,Color.Yellow },
            new Color[]{Color.Red,Color.Green },
            new Color[]{Color.Blue,Color.White },
            new Color[]{Color.Blue,Color.Orange },
            new Color[]{Color.Blue,Color.Yellow },
            new Color[]{ Color.Blue,Color.Red},
            new Color[]{Color.Yellow,Color.Green },
            new Color[]{Color.Yellow,Color.Red },
            new Color[]{Color.Yellow,Color.Blue },
            new Color[]{Color.Yellow,Color.Orange },

            
        };
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.PreferredBackBufferWidth = 1800;
            _graphics.ApplyChanges();
            cube.InitialiseCube();
            base.Initialize();
            timer = 60;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tex = Content.Load<Texture2D>("rubik");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ff[i, j] = new Sprite(tex, new Vector2(500 + 100 * i, 300 + 100 * j), new Vector2(100, 100));
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    rf[i, j] = new Sprite(tex, new Vector2(800 + 100 * i, 300 + 100 * j), new Vector2(100, 100));
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    lf[i, j] = new Sprite(tex, new Vector2(200 + 100 * i, 300 + 100 * j), new Vector2(100, 100));
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    df[i, j] = new Sprite(tex, new Vector2(500 + 100 * i, 600 + 100 * j), new Vector2(100, 100));
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    uf[i, j] = new Sprite(tex, new Vector2(500 + 100 * i, 100 * j), new Vector2(100, 100));
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    bf[i, j] = new Sprite(tex, new Vector2(1300 + 100 * i, 100 + 100 * j), new Vector2(100, 100));
                }
            }

            // TODO: use this.Content to load your game content here
        }



        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            cube.UpdateCube(gameTime);
            void DoAlgorithm(CubeM cubeM)
            {
                for (int i = 0; i < edgealgo.Length; i++)
                {
                    cubeM.Turn(edgealgo[i],gameTime);
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                Thread.Sleep(100);
                bfind = new Color[2]
                { cube.cubeorientationup[2, 1],cube.cubeorientationright[1, 0]};


                for (int i = 0; i < 23; i++)
                {
                    if (bfind[0] == wholecubenew[i][0] && bfind[1] == wholecubenew[i][1])
                    {

                        switch (i)
                        {
                            case 0:
                                cube.Turn(71, gameTime);
                                cube.Turn(71, gameTime);
                                cube.Turn(50, gameTime);
                                cube.Turn(7, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                             
                                cube.Turn(81, gameTime);
                                cube.Turn(81, gameTime);
                                cube.Turn(20, gameTime);
                                cube.Turn(8, gameTime);
                                cube.Turn(8, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 1:
                                //find anything to swap     //  RECURSION
                                //Solve(cube, unsolved[0]);
                                break;
                            case 2:
                                cube.Turn(71, gameTime);
                                cube.Turn(71, gameTime);
                                cube.Turn(20, gameTime);
                                cube.Turn(7, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                     
                                cube.Turn(81, gameTime);
                                cube.Turn(81, gameTime);
                                cube.Turn(50, gameTime);
                                cube.Turn(8, gameTime);
                                cube.Turn(8, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 3:
                                DoAlgorithm(cube);
                                unsolved.Remove(i);
                                break;
                            case 4:
                                cube.Turn(7, gameTime);
                                cube.Turn(501, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                                cube.Turn(8, gameTime);
                                cube.Turn(201, gameTime);
                                cube.Turn(8, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 5:
                                cube.Turn(501, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                   
                                cube.Turn(8, gameTime);
                                cube.Turn(201, gameTime); ;
                                unsolved.Remove(i);
                                break;
                            case 6:
                                cube.Turn(8, gameTime);
                                cube.Turn(501, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                     ;
                                cube.Turn(8, gameTime);
                                cube.Turn(201, gameTime);
                                cube.Turn(7, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 7:
                                cube.Turn(201, gameTime);
                                cube.Turn(8, gameTime);
                                DoAlgorithm(cube);
                  
                                cube.Turn(7, gameTime);
                                cube.Turn(501, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 8:
                                cube.Turn(71, gameTime);
                                cube.Turn(5, gameTime);
                                cube.Turn(7, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                          
                                cube.Turn(8, gameTime);
                                cube.Turn(8, gameTime);
                                cube.Turn(2, gameTime);
                                cube.Turn(81, gameTime);
                                unsolved.Remove(i);

                                break;
                            case 9:
                                cube.Turn(501, gameTime);
                                cube.Turn(501, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                              
                                cube.Turn(8, gameTime);
                                cube.Turn(201, gameTime);
                                cube.Turn(201, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 10:
                                cube.Turn(501, gameTime);
                                cube.Turn(7, gameTime);
                                cube.Turn(201, gameTime);
                                cube.Turn(8, gameTime);
                                DoAlgorithm(cube);
                             
                                cube.Turn(7, gameTime);
                                cube.Turn(501, gameTime);
                                cube.Turn(8, gameTime);
                                cube.Turn(201, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 11:
                                cube.Turn(8, gameTime);
                                DoAlgorithm(cube);
                          
                                cube.Turn(7, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 12:
                                //find anything to swap     //  RECURSION
                                //Solve(cube, unsolved[0]);
                                break;
                            case 13:
                                cube.Turn(201, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                         
                                cube.Turn(8, gameTime);
                                cube.Turn(501, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 14:
                                cube.Turn(20, gameTime);
                                cube.Turn(20, gameTime);
                                cube.Turn(8, gameTime);
                                cube.Turn(501, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                                cube.Turn(8, gameTime);
                                cube.Turn(201, gameTime);
                                cube.Turn(7, gameTime);
                                cube.Turn(50, gameTime);
                                cube.Turn(50, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 15:
                                cube.Turn(501, gameTime);
                                cube.Turn(8, gameTime);
                                DoAlgorithm(cube);
                        
                                cube.Turn(201, gameTime);
                                cube.Turn(7, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 16:
                                cube.Turn(81, gameTime);
                                cube.Turn(20, gameTime);
                                cube.Turn(7, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                       
                                cube.Turn(8, gameTime);
                                cube.Turn(8, gameTime);
                                cube.Turn(50, gameTime);
                                cube.Turn(71, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 17:
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                              
                                cube.Turn(8, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 18:
                                cube.Turn(81, gameTime);
                                cube.Turn(50, gameTime);
                                cube.Turn(7, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                              
                                cube.Turn(8, gameTime);
                                cube.Turn(8, gameTime);
                                cube.Turn(20, gameTime);
                                cube.Turn(71, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 19:
                            
                                cube.Turn(501, gameTime);
                             
                            
                                cube.Turn(501, gameTime);
                            
                                cube.Turn(8, gameTime);
                             
                            DoAlgorithm(cube);
                            
                                cube.Turn(7, gameTime);
                             
                                cube.Turn(201, gameTime);
                              
                                cube.Turn(201, gameTime);
                               
                            unsolved.Remove(i);
                            break;
                            case 20:
                                cube.Turn(50, gameTime);
                                cube.Turn(7, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                             
                                cube.Turn(8, gameTime);
                                cube.Turn(8, gameTime);
                                cube.Turn(20, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 21:
                                cube.Turn(50, gameTime);
                                cube.Turn(50, gameTime);
                                cube.Turn(7, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                                cube.Turn(8, gameTime);
                                cube.Turn(8, gameTime);
                                cube.Turn(20, gameTime);
                                cube.Turn(20, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 22:
                                cube.Turn(20, gameTime);
                                cube.Turn(7, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
                                
                                cube.Turn(8, gameTime);
                                cube.Turn(8, gameTime);
                                cube.Turn(50, gameTime);
                                unsolved.Remove(i);
                                break;
                            case 23:
                                cube.Turn(7, gameTime);
                                cube.Turn(7, gameTime);
                                DoAlgorithm(cube);
              
                                cube.Turn(7, gameTime); ;
                                cube.Turn(7, gameTime);
                                unsolved.Remove(i);
                                break;





                        }
                    }
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Color temp = cube.cubeorientationfront[i, j];
                    ff[i, j].spriteColor = temp;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Color temp = cube.cubeorientationup[i, j];
                    uf[i, j].spriteColor = temp;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Color temp = cube.cubeorientationdown[i, j];
                    df[i, j].spriteColor = temp;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Color temp = cube.cubeorientationright[i, j];
                    rf[i, j].spriteColor = temp;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Color temp = cube.cubeorientationleft[i, j];
                    lf[i, j].spriteColor = temp;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Color temp = cube.cubeorientationback[i, j];
                    bf[i, j].spriteColor = temp;
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            foreach (Sprite s in ff)
            {
                s.DrawSprite(_spriteBatch, s.spriteTexture);
            }
            foreach (Sprite s in rf)
            {
                s.DrawSprite(_spriteBatch, s.spriteTexture);
            }
            foreach (Sprite s in lf)
            {
                s.DrawSprite(_spriteBatch, s.spriteTexture);
            }
            foreach (Sprite s in uf)
            {
                s.DrawSprite(_spriteBatch, s.spriteTexture);
            }
            foreach (Sprite s in df)
            {
                s.DrawSprite(_spriteBatch, s.spriteTexture);
            }
            foreach (Sprite s in bf)
            {
                s.DrawSprite(_spriteBatch, s.spriteTexture);
            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}