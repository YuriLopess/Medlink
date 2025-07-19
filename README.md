<h1>MedLink</h1>

<h2>Descrição:</h2>

<p>Este projeto é uma API REST desenvolvida com foco em práticas de arquitetura limpa utilizando a Onion Architecture. A API permite o gerenciamento de consultas médicas entre pacientes e profissionais de saúde, garantindo regras de negócio claras, como verificação de disponibilidade, controle de agendamentos e cancelamentos.</p>

<h2>Entidades:</h2>

- **`Paciente`**: id, nome, email, cpf, dataNascimento
- **`Médico`**: id, nome, especialidade, crm, email
- **`Consulta`**: id, medicoId, pacienteId, dataHora, status

<h2>Regras de Negócio:</h2>

- Um médico não pode ter duas consultas no mesmo horário
- Consulta só pode ser marcada com pelo menos 24h de antecedência
- Consulta pode ser cancelada, mas não após seu horário
- Consultas devem ter status: `Agendada`, `Cancelada`, `Concluída`

<h2>Requisitos Funcionais:</h2>

| Código | Descrição                                                                 |
|--------|---------------------------------------------------------------------------|
| RF01   | O paciente pode se cadastrar no sistema                                   |
| RF02   | O médico pode se cadastrar com sua especialidade                          |
| RF03   | O paciente pode agendar uma consulta com um médico                        |
| RF04   | O paciente pode visualizar seus agendamentos                              |
| RF05   | O médico pode visualizar sua agenda de consultas                          |
| RF06   | O paciente pode cancelar um agendamento com pelo menos 24h de antecedência|
| RF07   | O sistema deve impedir agendamentos em horários já ocupados               |
| RF08   | A consulta deve conter os status: Agendada, Cancelada ou Concluída        |

<h2>Estrutura do Projeto:</h2>


```plaintext
/src
├── Domain
│   ├── Entities
│   │   ├── Paciente.cs
│   │   ├── Medico.cs
│   │   └── Consulta.cs
│   └── Interfaces
│       ├── IConsultaRepository.cs
│       └── IAgendamentoService.cs
├── Application
│   ├── Services
│   │   └── AgendamentoService.cs
│   └── DTOs
│       ├── AgendamentoRequest.cs
│       └── ConsultaResponse.cs
├── Infrastructure
│   └── Persistence
│       ├── AppDbContext.cs
│       └── ConsultaRepository.cs
├── API
│   ├── Controllers
│   │   └── ConsultasController.cs
│   └── Program.cs
