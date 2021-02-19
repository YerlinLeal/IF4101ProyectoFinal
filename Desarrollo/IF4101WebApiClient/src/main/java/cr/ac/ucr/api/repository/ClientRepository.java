package cr.ac.ucr.api.repository;

import cr.ac.ucr.api.model.Client;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.jpa.repository.query.Procedure;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

@Repository
public interface ClientRepository extends JpaRepository<Client, Integer> {
    @Query("SELECT u FROM Client u WHERE u.email = :client_email")
    Client findByEmail(@Param("client_email") String client_email);

    @Procedure(name = "Client.insertClientServices")
    void insertClientServices(@Param("c_id") int c_id, @Param("s_id") int s_id);


}
