package cr.ac.ucr.api.service;

import cr.ac.ucr.api.model.Client;
import cr.ac.ucr.api.repository.ClientRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.transaction.Transactional;
import java.util.List;

@Service
@Transactional
public class ClientService {

    @Autowired
    private ClientRepository repository;

    public List<Client> listAll() {
        return repository.findAll();
    }

    public void save(Client client) {
        repository.save(client);
    }

    public Client get(int id) {
        return repository.findById(id).get();
    }

    public void delete(int id) {
        repository.deleteById(id);
    }

    public  Client getByEmail(String email){ return repository.findByEmail(email);}

    public void insertClientServicesSP(int c_id, int s_id) {
        repository.insertClientServices(c_id,s_id);
    }
}
