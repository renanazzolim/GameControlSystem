using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller {
    public class PartidaController {
        TimeController timeController = new TimeController();

        public void CriarPartidas(IList<Time> times, int campeonato) {
            try {
                if (timeController.ListarTimes().Count == 0) {
                    throw new Exception("Não é possível criar partidas sem ter times cadastrados");
                } else if (timeController.ListarTimes().Count < 3) {
                    throw new Exception("Permitido criar partidas com no mínimo 3 (três) times");
                } else if (ListarPartidasPorCampeonato(campeonato).Count > 0) {
                    throw new Exception("Já existem partidas cadastradas para esse campeonato");
                } else {
                    SalvarPartidas(CriarListaDePartidas(times), campeonato);
                }
            } catch (Exception exp) {
                throw exp;
            }

        }

        public IList<Partida> ListarPartidasPorCampeonato(int id) {
            IList<Partida> partidas;
            try {
                partidas = Partida.GetPartidasByCampeonato(id);
            } catch (Exception exp) {
                throw exp;
            }
            return partidas;
        }

        private void SalvarPartidas(IList<String> partidas, int campeonato) {
            
            Time timeUm = new Time();
            Time timeDois = new Time();

            try {
                foreach (String partida in partidas) {
                    timeUm = timeController.GetTimeById(Convert.ToInt32(partida.Substring(0, 1)));
                    timeDois = timeController.GetTimeById(Convert.ToInt32(partida.Substring(2, 1)));
                    // salva partidas passando sempre o primeiro time como anfitrião
                    // salva sempre uma rodada em casa e outra no adversário
                    SalvarPartida(timeUm.TimeId, timeDois.TimeId, timeUm.EstadioId, campeonato, 3); // daqui três dias
                    SalvarPartida(timeDois.TimeId, timeUm.TimeId, timeDois.EstadioId, campeonato, 5); // daqui cinco dias
                }
            } catch (Exception exp) {
                throw exp;
            }
        }

        private void SalvarPartida(int anf, int vis, int estadioId, int camp, int dias) {
            Partida partida = new Partida();
            try {
                DateTime hoje = DateTime.Now;
                DateTime date = hoje.AddDays(dias);
                partida.Data = date.ToShortDateString();
                partida.EstadioId = estadioId;
                partida.AnfitriaoId = anf;
                partida.VisitanteId = vis;
                partida.CampeonatoId = camp;
                Partida.Salvar(partida);
            } catch (Exception exp) {
                throw exp;
            }
        }

        private IList<String> CriarListaDePartidas(IList<Time> times) {
            int partidas = ((times.Count - 1) * times.Count)/2; // jogando apenas 1x com todos
            IList<String> listaJogos = new List<String>();

            try {
                Random r = new Random();
                String result = null;
                String invertido = null;
                Boolean existe = false;
                int anf = 0;
                int vis = 0;

                do {
                    anf = r.Next(1, times.Count + 1);
                    vis = r.Next(1, times.Count + 1);
                    if (anf != vis) {
                        result = anf + "-" + vis;
                        invertido = vis + "-" + anf;
                        if (listaJogos.Count == 0) {
                            listaJogos.Add(result);
                        } else {
                            for (int i = 0; i < listaJogos.Count; i++) {
                                if (listaJogos[i].Equals(result) || listaJogos[i].Equals(invertido)) {
                                    existe = true;
                                    break;
                                }
                            }
                            if (!existe) {
                                listaJogos.Add(result);
                            }
                        }
                        existe = false;
                    }
                } while (listaJogos.Count < partidas);
            } catch (Exception exp) {
                throw exp;
            }

            return listaJogos;
        }

    }
}
